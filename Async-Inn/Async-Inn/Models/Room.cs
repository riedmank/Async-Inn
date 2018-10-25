using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public string Name { get; set; }
        public Layout Layout { get; set; }

        public ICollection<HotelRoom> HotelRooms { get; set; }
        public ICollection<RoomAmenities> Amenities { get; set; }
    }

    public enum Layout
    {
        Studio = 0,
        OneBedroom = 1,
        TwoBedroom = 2
    }
}
