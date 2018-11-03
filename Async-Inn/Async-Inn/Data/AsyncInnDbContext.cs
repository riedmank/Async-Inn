using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Seed values loaded here into Database
        /// </summary>
        /// <param name="modelBuilder">Model Builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomAmenities>().HasKey(
                ra => new { ra.AmenitiesID, ra.RoomID }
                );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    HotelID = 1,
                    Name = "Plaza",
                    Address = "New York",
                    Phone = "555-0123"
                },
                new Hotel
                {
                    HotelID = 2,
                    Name = "Hotel Ritz",
                    Address = "Paris",
                    Phone = "555-0123"
                },
                new Hotel
                {
                    HotelID = 3,
                    Name = "Claridges",
                    Address = "London",
                    Phone = "555-0123"
                },
                new Hotel
                {
                    HotelID = 4,
                    Name = "Raffles",
                    Address = "Singapore",
                    Phone = "555-0123",
                },
                new Hotel
                {
                    HotelID = 5,
                    Name = "Taj Mahal Palace",
                    Address = "India",
                    Phone = "555-0123"
                },
                new Hotel
                {
                    HotelID = 6,
                    Name = "Beverly Hills Hotel",
                    Address = "Los Angeles",
                    Phone = "555-0123"
                }
                );
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    RoomID = 1,
                    Name = "The Barrens Bedroom",
                    Layout = Layout.Studio,
                },
                new Room
                {
                    RoomID = 2,
                    Name = "The Tanaris Niche",
                    Layout = Layout.Studio
                },
                new Room
                {
                    RoomID = 3,
                    Name = "The Ashenvale Forest Den",
                    Layout = Layout.OneBedroom
                },
                new Room
                {
                    RoomID = 4,
                    Name = "The Hinterlands Accommodation",
                    Layout = Layout.OneBedroom
                },
                new Room
                {
                    RoomID = 5,
                    Name = "The Badlands Cabin",
                    Layout = Layout.TwoBedroom
                },
                new Room
                {
                    RoomID = 6,
                    Name = "The Stranglethorn Vale Cabin",
                    Layout = Layout.TwoBedroom
                }
                );
            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    AmenitiesID = 1,
                    Name = "Plasma Screen TV"
                },
                new Amenities
                {
                    AmenitiesID = 2,
                    Name = "Jacuzzi",
                },
                new Amenities
                {
                    AmenitiesID = 3,
                    Name = "Putting Green"
                },
                new Amenities
                {
                    AmenitiesID = 4,
                    Name = "Basketball Court"
                },
                new Amenities
                {
                    AmenitiesID = 5,
                    Name = "In-Room Hibachi Grill with 24 hour Chef"
                }
                );
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
    }
}
