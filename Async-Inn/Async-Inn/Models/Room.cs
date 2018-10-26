using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        [Required]
        [Display(Name = "Room Name")]
        public string Name { get; set; }
        [Required]
        [EnumDataType(typeof(Layout))]
        public Layout Layout { get; set; }

        public ICollection<HotelRoom> HotelRooms { get; set; }
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }

    public enum Layout
    {
        [Display(Name = "Studio")]
        Studio,
        [Display(Name = "One Bedroom")]
        OneBedroom,
        [Display(Name = "Two Bedroom")]
        TwoBedroom
    }
}
