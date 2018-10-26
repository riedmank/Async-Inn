﻿// <auto-generated />
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncInn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    partial class AsyncInnDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsyncInn.Models.Amenities", b =>
                {
                    b.Property<int>("AmenitiesID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("AmenitiesID");

                    b.ToTable("Amenities");

                    b.HasData(
                        new { AmenitiesID = 1, Name = "Plasma Screen TV" },
                        new { AmenitiesID = 2, Name = "Jacuzzi" },
                        new { AmenitiesID = 3, Name = "Putting Green" },
                        new { AmenitiesID = 4, Name = "Basketball Court" },
                        new { AmenitiesID = 5, Name = "In-Room Hibachi Grill with 24 hour Chef" }
                    );
                });

            modelBuilder.Entity("AsyncInn.Models.Hotel", b =>
                {
                    b.Property<int>("HotelID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.HasKey("HotelID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new { HotelID = 1, Address = "New York", Name = "Plaza", Phone = "555-0123" },
                        new { HotelID = 2, Address = "Paris", Name = "Hotel Ritz", Phone = "555-0123" },
                        new { HotelID = 3, Address = "London", Name = "Claridges", Phone = "555-0123" },
                        new { HotelID = 4, Address = "Singapore", Name = "Raffles", Phone = "555-0123" },
                        new { HotelID = 5, Address = "India", Name = "Taj Mahal Palace", Phone = "555-0123" },
                        new { HotelID = 6, Address = "Los Angeles", Name = "Beverly Hills Hotel", Phone = "555-0123" }
                    );
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.Property<int>("RoomNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HotelID");

                    b.Property<bool>("PetFriendly");

                    b.Property<decimal>("Rate");

                    b.Property<int>("RoomID");

                    b.HasKey("RoomNumber");

                    b.HasIndex("HotelID");

                    b.HasIndex("RoomID");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("AsyncInn.Models.Room", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("RoomID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new { RoomID = 1, Layout = 0, Name = "The Barrens Bedroom" },
                        new { RoomID = 2, Layout = 0, Name = "The Tanaris Niche" },
                        new { RoomID = 3, Layout = 1, Name = "The Ashenvale Forest Den" },
                        new { RoomID = 4, Layout = 1, Name = "The Hinterlands Accommodation" },
                        new { RoomID = 5, Layout = 2, Name = "The Badlands Cabin" },
                        new { RoomID = 6, Layout = 2, Name = "The Stranglethorn Vale Cabin" }
                    );
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.Property<int>("AmenitiesID");

                    b.Property<int>("RoomID");

                    b.HasKey("AmenitiesID", "RoomID");

                    b.HasIndex("RoomID");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.HasOne("AsyncInn.Models.Hotel", "Hotel")
                        .WithMany("HotelRooms")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany("HotelRooms")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.HasOne("AsyncInn.Models.Amenities", "Amenities")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenitiesID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
