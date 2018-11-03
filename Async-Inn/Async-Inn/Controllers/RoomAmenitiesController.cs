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
    public class RoomAmenitiesController : Controller
    {
        private readonly IAmenities _amenity;
        private readonly IRoom _room;
        private readonly AsyncInnDbContext _context;

        public RoomAmenitiesController(IAmenities amenity, IRoom room, AsyncInnDbContext context)
        {
            _amenity = amenity;
            _room = room;
            _context = context;
        }

        /// <summary>
        /// Gets all Room Amenities
        /// </summary>
        /// <returns>Returns Index view of Room Amenities</returns>
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.RoomAmenities.Include(r => r.Amenities).Include(r => r.Room);
            return View(await asyncInnDbContext.ToListAsync());
        }

        /// <summary>
        /// Details of specific Room Amenity
        /// </summary>
        /// <param name="RoomID">Room ID</param>
        /// <param name="AmenitiesID">Amenity ID</param>
        /// <returns>Returns Detail view of Room Amenity</returns>
        public IActionResult Details(int RoomID, int AmenitiesID)
        {
            var roomAmenities = _room.GetRoomAmenitiesByRoom(RoomID, AmenitiesID);
            if (roomAmenities == null)
            {
                return NotFound();
            }

            return View(roomAmenities);
        }

        /// <summary>
        /// Create Room Amenity
        /// </summary>
        /// <returns>Returns Create view of Room Amenities</returns>
        public IActionResult Create()
        {
            ViewData["AmenitiesID"] = new SelectList(_context.Amenities, "AmenitiesID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "Name");
            return View();
        }

        /// <summary>
        /// Create Room Amenity
        /// </summary>
        /// <param name="roomAmenities">Amenity and Room</param>
        /// <returns>Returns Room Amenity view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AmenitiesID,RoomID")] RoomAmenities roomAmenities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomAmenities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmenitiesID"] = new SelectList(_context.Amenities, "AmenitiesID", "Name", roomAmenities.AmenitiesID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "Name", roomAmenities.RoomID);
            return View(roomAmenities);
        }

        /// <summary>
        /// Delete Room Amenity
        /// </summary>
        /// <param name="RoomID">Room ID</param>
        /// <param name="AmenitiesID">Amenity ID</param>
        /// <returns>Returns Delete Room Amenity view</returns>
        public IActionResult Delete(int RoomID, int AmenitiesID)
        {
            var roomAmenities = _room.GetRoomAmenitiesByRoom(RoomID, AmenitiesID);
            if (roomAmenities == null)
            {
                return NotFound();
            }

            return View(roomAmenities);
        }

        /// <summary>
        /// Delete Room Amenity
        /// </summary>
        /// <param name="RoomID">Room ID</param>
        /// <param name="AmenitiesID">Room ID</param>
        /// <returns>Returns Index view</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int RoomID, int AmenitiesID)
        {
            var roomAmenities = _room.GetRoomAmenitiesByRoom(RoomID, AmenitiesID);
            _context.RoomAmenities.Remove(roomAmenities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomAmenitiesExists(int id)
        {
            return _context.RoomAmenities.Any(e => e.AmenitiesID == id);
        }
    }
}
