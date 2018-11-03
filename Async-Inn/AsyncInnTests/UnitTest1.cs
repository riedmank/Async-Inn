using AsyncInn.Data;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using static AsyncInn.Program;

namespace AsyncInnTests
{
    public class UnitTest1
    {
        /// <summary>
        /// Tests Amenity Getter
        /// </summary>
        [Fact]
        public void CanGetAmenityName()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "MyAmenity";

            Assert.Equal("MyAmenity", amenity.Name);
        }

        /// <summary>
        /// Tests Amenity Setter
        /// </summary>
        [Fact]
        public void CanSetAmenityName()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "MyAmenity";

            amenity.Name = "YourAmenity";

            Assert.Equal("YourAmenity", amenity.Name);
        }

        /// <summary>
        /// Tests Room Getter
        /// </summary>
        [Fact]
        public void CanGetRoomName()
        {
            Room room = new Room();
            room.Name = "MyRoom";

            Assert.Equal("MyRoom", room.Name);
        }

        /// <summary>
        /// Tests Room Setter
        /// </summary>
        [Fact]
        public void CanSetRoomName()
        {
            Room room = new Room();
            room.Name = "MyRoom";

            room.Name = "YourRoom";

            Assert.Equal("YourRoom", room.Name);
        }

        /// <summary>
        /// Tests Hotel Getter
        /// </summary>
        [Fact]
        public void CanGetHotelName()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "MyHotel";

            Assert.Equal("MyHotel", hotel.Name);
        }

        /// <summary>
        /// Tests Hotel Setter
        /// </summary>
        [Fact]
        public void CanSetHotelName()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "MyHotel";

            hotel.Name = "YourHotel";

            Assert.Equal("YourHotel", hotel.Name);
        }

        /// <summary>
        /// Tests HotelRoom Getter
        /// </summary>
        [Fact]
        public void CanGetHotelRoomRate()
        {
            HotelRoom hotelroom = new HotelRoom();
            hotelroom.Rate = 20m;

            Assert.Equal(20m, hotelroom.Rate);
        }

        /// <summary>
        /// Tests HotelRoom Setter
        /// </summary>
        [Fact]
        public void CanSetHotelRoomRate()
        {
            HotelRoom hotelroom = new HotelRoom();
            hotelroom.Rate = 20m;

            hotelroom.Rate = 40m;

            Assert.Equal(40m, hotelroom.Rate);
        }

        /// <summary>
        /// Tests RoomAmenities Getter
        /// </summary>
        [Fact]
        public void CanGetRoomAmenities()
        {
            RoomAmenities ra = new RoomAmenities();
            Amenities amenity = new Amenities();
            ra.Amenities = amenity;
            amenity.Name = "MyAmenity";

            Assert.Equal("MyAmenity", ra.Amenities.Name);
        }

        /// <summary>
        /// Tests RoomAmenities Setter
        /// </summary>
        [Fact]
        public void CanSetRoomAmenitiesName()
        {
            RoomAmenities ra = new RoomAmenities();
            Amenities amenity = new Amenities();
            ra.Amenities = amenity;
            amenity.Name = "MyAmenity";

            amenity.Name = "YourAmenity";

            Assert.Equal("YourAmenity", ra.Amenities.Name);
        }

        /// <summary>
        /// Tests Create and Read on Amenities Table
        /// </summary>
        [Fact]
        public async void CanSaveAmenityInDb()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetAmenityName")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenity = new Amenities();
                amenity.Name = "MyAmenity";

                context.Amenities.Add(amenity);
                context.SaveChanges();

                var amenityName = await context.Amenities.FirstOrDefaultAsync(x => x.Name == amenity.Name);

                Assert.Equal("MyAmenity", amenityName.Name);
            }
        }

        /// <summary>
        /// Tests Update on Amenities Table
        /// </summary>
        [Fact]
        public async void CanUpdateAmenityInDb()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetAmenityName")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenity = new Amenities();
                amenity.Name = "MyAmenity";

                amenity.Name = "YourAmenity";

                context.Amenities.Update(amenity);
                context.SaveChanges();

                var amenityName = await context.Amenities.FirstOrDefaultAsync(x => x.Name == amenity.Name);

                Assert.Equal("YourAmenity", amenityName.Name);
            }
        }

        /// <summary>
        /// Tests Delete on Amenities Table
        /// </summary>
        [Fact]
        public async void CanDeleteAmenityInDb()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetAmenityName")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenity = new Amenities();
                amenity.Name = "MyAmenity";

                context.Amenities.Add(amenity);
                context.SaveChanges();

                context.Amenities.Remove(amenity);
                context.SaveChanges();

                var amenities = await context.Amenities.ToListAsync();

                Assert.DoesNotContain(amenity, amenities);
            }
        }

        /// <summary>
        /// Tests Create and Read on Hotels Table
        /// </summary>
        [Fact]
        public async void CanSaveHotelDb()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetHotelName")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.Name = "MyHotel";

                context.Hotels.Add(hotel);
                context.SaveChanges();

                var hotelName = await context.Hotels.FirstOrDefaultAsync(x => x.Name == hotel.Name);

                Assert.Equal("MyHotel", hotelName.Name);
            }
        }

        /// <summary>
        /// Tests Update on Hotels Table
        /// </summary>
        [Fact]
        public async void CanUpdateHotelInDb()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetHotelName")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.Name = "MyHotel";

                context.Hotels.Add(hotel);
                context.SaveChanges();

                hotel.Name = "YourHotel";

                context.Hotels.Update(hotel);
                context.SaveChanges();

                var hotelName = await context.Hotels.FirstOrDefaultAsync(x => x.Name == hotel.Name);

                Assert.Equal("YourHotel", hotelName.Name);
            }
        }

        /// <summary>
        /// Tests Delete on Hotels Table
        /// </summary>
        [Fact]
        public async void CanDeleteHotelInDb()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetHotelName")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.Name = "MyHotel";

                context.Hotels.Add(hotel);
                context.SaveChanges();

                context.Hotels.Remove(hotel);
                context.SaveChanges();

                var hotels = await context.Hotels.ToListAsync();

                Assert.DoesNotContain(hotel, hotels);
            }
        }

        /// <summary>
        /// Tests Create and Read on Rooms Table
        /// </summary>
        [Fact]
        public async void CanSaveRoomDb()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetRoomName")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room room = new Room();
                room.Name = "MyRoom";

                context.Rooms.Add(room);
                context.SaveChanges();

                var roomName = await context.Rooms.FirstOrDefaultAsync(x => x.Name == room.Name);

                Assert.Equal("MyRoom", roomName.Name);
            }
        }

        /// <summary>
        /// Tests Update on Rooms Table
        /// </summary>
        [Fact]
        public async void CanUpdateRoomInDb()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetRoomName")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room room = new Room();
                room.Name = "MyRoom";

                context.Rooms.Add(room);
                context.SaveChanges();

                room.Name = "YourRoom";

                context.Rooms.Update(room);
                context.SaveChanges();

                var roomName = await context.Rooms.FirstOrDefaultAsync(x => x.Name == room.Name);

                Assert.Equal("YourRoom", roomName.Name);
            }
        }
        
        /// <summary>
        /// Tests Delete on Rooms Table
        /// </summary>
        [Fact]
        public async void CanDeleteRoomInDb()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetRoomName")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room room = new Room();
                room.Name = "MyRoom";

                context.Rooms.Add(room);
                context.SaveChanges();

                context.Rooms.Remove(room);
                context.SaveChanges();

                var rooms = await context.Rooms.ToListAsync();

                Assert.DoesNotContain(room, rooms);
            }
        }

        /// <summary>
        /// Tests Create and Read on HotelRooms Table
        /// </summary>
        [Fact]
        public async void CanSaveHotelRoomDb()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetHotelRoomRate")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                HotelRoom hr = new HotelRoom();
                hr.Rate = 20m;

                context.HotelRooms.Add(hr);
                context.SaveChanges();

                var hotelRate = await context.HotelRooms.FirstOrDefaultAsync(x => x.Rate == hr.Rate);

                Assert.Equal(20m, hotelRate.Rate);
            }
        }

        /// <summary>
        /// Tests Update on HotelRooms Table
        /// </summary>
        [Fact]
        public async void CanUpdateHotelRoomInDb()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetHotelRoomRate")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                HotelRoom hr = new HotelRoom();
                hr.Rate = 20m;

                context.HotelRooms.Add(hr);
                context.SaveChanges();

                hr.Rate = 40m;

                context.HotelRooms.Update(hr);
                context.SaveChanges();

                var hotelRate = await context.HotelRooms.FirstOrDefaultAsync(x => x.Rate == hr.Rate);

                Assert.Equal(40m, hotelRate.Rate);
            }
        }
        
        /// <summary>
        /// Tests Delete on Hotel Rooms Table
        /// </summary>
        [Fact]
        public async void CanDeleteHotelRoomInDb()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetHotelRoomName")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                HotelRoom hr = new HotelRoom();
                hr.Rate = 20m;

                context.HotelRooms.Add(hr);
                context.SaveChanges();

                context.HotelRooms.Remove(hr);
                context.SaveChanges();

                var hotelrooms = await context.HotelRooms.ToListAsync();

                Assert.DoesNotContain(hr, hotelrooms);
            }
        }

        /// <summary>
        /// Tests Create and Read on Room Amenities Table
        /// </summary>
        [Fact]
        public async void CanSaveRoomAmenityDb()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetRoomAmenityName")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenity = new Amenities();
                amenity.Name = "MyAmenity";
                RoomAmenities ra = new RoomAmenities();
                ra.Amenities = amenity;

                context.RoomAmenities.Add(ra);
                context.SaveChanges();

                var amenityName = await context.RoomAmenities.FirstOrDefaultAsync(x => x.Amenities == amenity);

                Assert.Contains("MyAmenity", amenityName.Amenities.Name);
            }
        }
        
        /// <summary>
        /// Tests Delete in Room Amenity Table
        /// </summary>
        [Fact]
        public async void CanDeleteRoomAmenityInDb()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetRoomAmenityName")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                RoomAmenities ra = new RoomAmenities();
                Amenities amenity = new Amenities();
                amenity.Name = "MyAmenity";

                ra.Amenities = amenity;

                context.RoomAmenities.Add(ra);
                context.SaveChanges();

                context.RoomAmenities.Remove(ra);
                context.SaveChanges();

                var roomamenities = await context.RoomAmenities.ToListAsync();

                Assert.DoesNotContain(ra, roomamenities);
            }
        }
    }
}
