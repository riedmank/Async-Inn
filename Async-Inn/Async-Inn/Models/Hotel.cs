using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Hotel
    {
        public int HotelID { get; set; }
        [Required]
        [Display(Name = "Hotel Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Hotel Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Hote Phone Number")]
        public string Phone { get; set; }

        public ICollection<HotelRoom> HotelRooms { get; set; }
    }
}
