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

        public async Task CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            var room = await GetRoom(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int? id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(x => x.RoomID == id);
        }

        public HotelRoom GetHotelRoomByRoom(int RoomID)
        {
            var hotelRoom = _context.HotelRooms
                .Where(x => x.RoomID == RoomID)
                .Include(h => h.Hotel)
                .Include(r => r.Room).FirstOrDefault();
            return hotelRoom;
        }

        public IEnumerable<RoomAmenities> GetRoomAmenitiesByRoom(int RoomID)
        {
            var roomAmenities = _context.RoomAmenities
                .Where(x => x.RoomID == RoomID)
                .Include(a => a.Amenities)
                .Include(r => r.Room);
            return roomAmenities;
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }
    }
}
