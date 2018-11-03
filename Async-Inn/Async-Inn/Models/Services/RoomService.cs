using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class RoomService : IRoom
    {
        private AsyncInnDbContext _context;

        public RoomService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create Room
        /// </summary>
        /// <param name="room">Create Room information</param>
        /// <returns>Returns Task</returns>
        public async Task CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete Room
        /// </summary>
        /// <param name="id">Room ID</param>
        /// <returns>Returns Task</returns>
        public async Task DeleteRoom(int id)
        {
            var room = await GetRoom(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get Room
        /// </summary>
        /// <param name="id">Room ID</param>
        /// <returns>Returns Room</returns>
        public async Task<Room> GetRoom(int? id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(x => x.RoomID == id);
        }

        /// <summary>
        /// Get Hotel Room
        /// </summary>
        /// <param name="id">Room ID</param>
        /// <returns>Returns Hotel Room</returns>
        public HotelRoom GetHotelRoomByRoom(int id)
        {
            var hotelRoom = _context.HotelRooms
                .Where(x => x.RoomID == id)
                .Include(h => h.Hotel)
                .Include(r => r.Room).FirstOrDefault();
            return hotelRoom;
        }

        /// <summary>
        /// Get Room Amenities
        /// </summary>
        /// <param name="RoomID">Room ID</param>
        /// <param name="AmenitiesID">Amenities ID</param>
        /// <returns>Returns Room Amenity</returns>
        public RoomAmenities GetRoomAmenitiesByRoom(int RoomID, int AmenitiesID)
        {
            var roomAmenities = _context.RoomAmenities
                .Where(x => x.RoomID == RoomID && x.AmenitiesID == AmenitiesID)
                .Include(a => a.Amenities)
                .Include(r => r.Room).FirstOrDefault();
            return roomAmenities;
        }

        /// <summary>
        /// Get Rooms
        /// </summary>
        /// <returns>Returns List of Rooms</returns>
        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        /// <summary>
        /// Update Room
        /// </summary>
        /// <param name="room">Update Room information</param>
        /// <returns>Returns Task</returns>
        public async Task UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }
    }
}
