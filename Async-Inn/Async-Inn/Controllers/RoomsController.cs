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
    public class RoomsController : Controller
    {
        private readonly IRoom _room;

        public RoomsController(IRoom context)
        {
            _room = context;
        }

        /// <summary>
        /// Called on the Index page for Rooms
        /// </summary>
        /// <returns>Returns all rooms</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _room.GetRooms());
        }

        /// <summary>
        /// Searches for a specific Room
        /// </summary>
        /// <param name="SearchField">Search string from the user</param>
        /// <returns>Returns searched for room</returns>
        [HttpPost]
        public async Task<IActionResult> Index(string SearchField)
        {
            var Rooms = await _room.GetRooms();

            Rooms = Rooms.Where(room => room.Name.Contains(SearchField)).ToList();

            return View(Rooms);
        }

        /// <summary>
        /// Gets Details for a specific Room
        /// </summary>
        /// <param name="id">Room ID from View</param>
        /// <returns>Returns specific Room</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _room.GetRoom(id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        /// <summary>
        /// Displays the Create View
        /// </summary>
        /// <returns>Returns the Create View</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a Room
        /// </summary>
        /// <param name="room">User input about the Room</param>
        /// <returns>Returns the Room just added</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomID,Name,Layout")] Room room)
        {
            if (ModelState.IsValid)
            {
                await _room.CreateRoom(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        /// <summary>
        /// Edit a Room view
        /// </summary>
        /// <param name="id">ID of Room to be Edited</param>
        /// <returns>Returns the Edit view of the Room to be Edited</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _room.GetRoom(id);

            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        /// <summary>
        /// Edit a Room View
        /// </summary>
        /// <param name="id">ID of Room that is being Edited</param>
        /// <param name="room">New information for the Room</param>
        /// <returns>Returns the Room that was Edited</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomID,Name,Layout")] Room room)
        {
            if (id != room.RoomID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _room.UpdateRoom(room);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.RoomID))
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
            return View(room);
        }

        /// <summary>
        /// Delete a Room View
        /// </summary>
        /// <param name="id">ID of the Room to be Deleted</param>
        /// <returns>Returns the Delete view for a Room</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _room.GetRoom(id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        /// <summary>
        /// Delete a Room
        /// </summary>
        /// <param name="id">ID of the Room to be Deleted</param>
        /// <returns>Returns Index view</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _room.DeleteRoom(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _room.GetRoom(id) != null;
        }
    }
}
