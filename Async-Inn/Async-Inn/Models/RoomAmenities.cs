using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        [Required]
        [Display(Name = "Amenity")]
        public int AmenitiesID { get; set; }
        [Required]
        [Display(Name = "Room")]
        public int RoomID { get; set; }

        public Room Room { get; set; }        
        public Amenities Amenities { get; set; }
    }
}
