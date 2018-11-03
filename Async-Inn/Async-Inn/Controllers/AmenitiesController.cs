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
    public class AmenitiesController : Controller
    {
        private readonly IAmenities _amenities;

        public AmenitiesController(IAmenities context)
        {
            _amenities = context;
        }

        /// <summary>
        /// Get Amenities
        /// </summary>
        /// <returns>Return Index view of Amenities</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _amenities.GetAmenities());
        }

        /// <summary>
        /// Get Amenity
        /// </summary>
        /// <param name="id">Amenity ID</param>
        /// <returns>Returns Detail view of Amenity</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenities = await _amenities.GetAmenities(id);
            
            if (amenities == null)
            {
                return NotFound();
            }

            return View(amenities);
        }

        /// <summary>
        /// Create Amenity
        /// </summary>
        /// <returns>Returns Amenity Create view</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create Amenity
        /// </summary>
        /// <param name="amenities">Create Amenity information</param>
        /// <returns>Returns Amenity view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AmenitiesID,Name")] Amenities amenities)
        {
            if (ModelState.IsValid)
            {
                await _amenities.CreateAmenity(amenities);
                return RedirectToAction(nameof(Index));
            }
            return View(amenities);
        }

        /// <summary>
        /// Edit Amenity
        /// </summary>
        /// <param name="id">Amenity ID</param>
        /// <returns>Returns Amenity Edit view</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenities = await _amenities.GetAmenities(id);

            if (amenities == null)
            {
                return NotFound();
            }
            return View(amenities);
        }

        /// <summary>
        /// Edit Amenity
        /// </summary>
        /// <param name="id">Amenity ID</param>
        /// <param name="amenities">Amenity Edit information</param>
        /// <returns>Returns Amenity view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AmenitiesID,Name")] Amenities amenities)
        {
            if (id != amenities.AmenitiesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _amenities.UpdateAmenity(amenities);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmenitiesExists(amenities.AmenitiesID))
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
            return View(amenities);
        }

        /// <summary>
        /// Delete Amenity
        /// </summary>
        /// <param name="id">Amenity ID</param>
        /// <returns>Returns Delete Amenity view</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenities = await _amenities.GetAmenities(id);
               
            if (amenities == null)
            {
                return NotFound();
            }

            return View(amenities);
        }

        /// <summary>
        /// Delete Amenity
        /// </summary>
        /// <param name="id">Amenity ID</param>
        /// <returns>Returns Amneity Index view</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _amenities.DeleteAmenity(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AmenitiesExists(int id)
        {
            return _amenities.GetAmenities(id) != null;
        }
    }
}
