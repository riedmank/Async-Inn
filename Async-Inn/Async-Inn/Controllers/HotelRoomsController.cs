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
    public class HotelRoomsController : Controller
    {
        private readonly AsyncInnDbContext _context;
        private readonly IRoom _room;
        private readonly IHotel _hotel;

        public HotelRoomsController(IRoom room, IHotel hotel, AsyncInnDbContext context)
        {
            _context = context;
            _room = room;
            _hotel = hotel;
        }

        /// <summary>
        /// Gets Hotel Rooms
        /// </summary>
        /// <returns>Returns Index view of Hotel Rooms</returns>
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.HotelRooms.Include(h => h.Hotel).Include(h => h.Room);
            return View(await asyncInnDbContext.ToListAsync());
        }

        /// <summary>
        /// Detail of Hotel Room
        /// </summary>
        /// <param name="id">Room ID</param>
        /// <returns>Returns Detail view of Hotel Room</returns>
        public IActionResult Details(int id)
        {
            var hotelRoom =  _room.GetHotelRoomByRoom(id);
            
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        /// <summary>
        /// Create Hotel Room
        /// </summary>
        /// <returns>Returns Create view for Hotel Room</returns>
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotels, "HotelID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "Name");
            return View();
        }

        /// <summary>
        /// Create Hotel Room
        /// </summary>
        /// <param name="hotelRoom">Hotel Room information</param>
        /// <returns>Returns Hotel Room view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomNumber,HotelID,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "HotelID", "Name", hotelRoom.Hotel.Name);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "Name", hotelRoom.Room.Name);
            return View(hotelRoom);
        }

        /// <summary>
        /// Edit Hotel Room
        /// </summary>
        /// <param name="id">RoomNumber</param>
        /// <returns>Returns Hotel Room Edit view</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms.FindAsync(id);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "HotelID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        /// <summary>
        /// Edit Hotel Room
        /// </summary>
        /// <param name="id">Room ID</param>
        /// <param name="hotelRoom">Hotel Room Number</param>
        /// <returns>Returns Hotel Room view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomNumber,HotelID,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (id != hotelRoom.RoomNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRoomExists(hotelRoom.RoomNumber))
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
            ViewData["HotelID"] = new SelectList(_context.Hotels, "HotelID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        /// <summary>
        /// Delete Hotel Room
        /// </summary>
        /// <param name="id">Room ID</param>
        /// <returns>Returns Hotel Room Delete view</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.RoomNumber == id);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        /// <summary>
        /// Delete Hotel Room
        /// </summary>
        /// <param name="id">Room ID</param>
        /// <returns>Returns Index view of Hotel Rooms</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelRoom = await _context.HotelRooms.FindAsync(id);
            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelRoomExists(int id)
        {
            return _context.HotelRooms.Any(e => e.RoomNumber == id);
        }
    }
}
