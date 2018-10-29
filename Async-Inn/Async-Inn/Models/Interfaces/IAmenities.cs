using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    interface IAmenities
    {
        Task CreateAmenity(Amenities amenities);
        Task UpdateAmenity(Amenities amenities);
        Task DeleteAmenity(int id);
        Task<List<Amenities>> GetAmenities();
        Task<Amenities> GetAmenities(int? id);
    }
}
