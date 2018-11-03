using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelService : IHotel
    {
        private AsyncInnDbContext _context;

        public HotelService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create Hotel
        /// </summary>
        /// <param name="hotel">Create Hotel information</param>
        /// <returns>Returns Task</returns>
        public async Task CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete Hotel
        /// </summary>
        /// <param name="id">Hotel ID</param>
        /// <returns>Returns Task</returns>
        public async Task DeleteHotel(int id)
        {
            var hotel = await GetHotel(id);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get Hotel
        /// </summary>
        /// <param name="id">Hotel ID</param>
        /// <returns>Returns Hotel</returns>
        public async Task<Hotel> GetHotel(int? id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(x => x.HotelID == id);
        }

        /// <summary>
        /// Get Hotels
        /// </summary>
        /// <returns>Returns List of Hotels</returns>
        public async Task<List<Hotel>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        /// <summary>
        /// Update Hotel
        /// </summary>
        /// <param name="hotel">Update Hotel information</param>
        /// <returns>Returns Task</returns>
        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
