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

        /// <summary>
        /// Get Hotels
        /// </summary>
        /// <returns>Returns Index view of Hotels</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _hotel.GetHotels());
        }

        /// <summary>
        /// Hotel Details
        /// </summary>
        /// <param name="id">Hotel ID</param>
        /// <returns>Returns Hotel Details view</returns>
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

        /// <summary>
        /// Create Hotel
        /// </summary>
        /// <returns>Returns Create Hotel view</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create Hotel
        /// </summary>
        /// <param name="hotel">Hotel information</param>
        /// <returns>Returns Hotel view</returns>
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

        /// <summary>
        /// Edit Hotel
        /// </summary>
        /// <param name="id">Hotel ID</param>
        /// <returns>Returns Edit Hotel view</returns>
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

        /// <summary>
        /// Edit Hotel
        /// </summary>
        /// <param name="id">Hotel ID</param>
        /// <param name="hotel">New Hotel information</param>
        /// <returns>Returns Hotel view</returns>
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

        /// <summary>
        /// Delete Hotel
        /// </summary>
        /// <param name="id">Hotel ID</param>
        /// <returns>Returns Delete Hotel view</returns>
        public async Task<IActionResult> Delete(int? id)
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

        /// <summary>
        /// Delete Hotel
        /// </summary>
        /// <param name="id">Hotel ID</param>
        /// <returns>Returns to Hotel Index view</returns>
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
