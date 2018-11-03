using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class AmenitiesService : IAmenities
    {
        private AsyncInnDbContext _context;

        public AmenitiesService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates an Amenity
        /// </summary>
        /// <param name="amenities">Amenity information from user</param>
        /// <returns>Returns Task</returns>
        public async Task CreateAmenity(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete Amenity
        /// </summary>
        /// <param name="id">Amenity ID</param>
        /// <returns>Returns Task</returns>
        public async Task DeleteAmenity(int id)
        {
            var amenities = await GetAmenities(id);
            _context.Amenities.Remove(amenities);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get Amenities
        /// </summary>
        /// <returns>Returns List of Amenities</returns>
        public async Task<List<Amenities>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        /// <summary>
        /// Get Amenity
        /// </summary>
        /// <param name="id">Amenity ID</param>
        /// <returns>Returns Amenity</returns>
        public async Task<Amenities> GetAmenities(int? id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(x => x.AmenitiesID == id);
        }

        /// <summary>
        /// Update Amenity
        /// </summary>
        /// <param name="amenities">Update Amenity information</param>
        /// <returns>Returns Task</returns>
        public async Task UpdateAmenity(Amenities amenities)
        {
            _context.Amenities.Update(amenities);
            await _context.SaveChangesAsync();
        }
    }
}
