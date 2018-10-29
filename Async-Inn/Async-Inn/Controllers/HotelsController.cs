using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;

namespace AsyncInn.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotel _hotel;

        public HotelsController(IHotel context)
        {
            _hotel = context;
        }

        // GET: Hotels
        public async Task<IActionResult> Index()
        {
            return View(await _hotel.GetHotels());
        }

        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _hotel.GetHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,Name,Address,Phone")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                await _hotel.CreateHotel(hotel);

                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _hotel.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotelID,Name,Address,Phone")] Hotel hotel)
        {
            if (id != hotel.HotelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _hotel.UpdateHotel(hotel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.HotelID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hotel hotel = await _hotel.GetHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _hotel.DeleteHotel(id);
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(int id)
        {
            return _hotel.GetHotel(id) != null;
        }
    }
}
