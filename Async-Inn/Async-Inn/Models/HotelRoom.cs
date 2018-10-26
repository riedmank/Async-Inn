using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        [Key]
        public int RoomNumber { get; set; }
        public int HotelID { get; set; }
        public int RoomID { get; set; }
        [Required]
        [Display(Name = "Nightly Rate")]
        public decimal Rate { get; set; }
        [Required]
        [Display(Name = "Pet Friendly")]
        public bool PetFriendly { get; set; }

        public Room Room { get; set; }
        public Hotel Hotel { get; set; }
    }
}
