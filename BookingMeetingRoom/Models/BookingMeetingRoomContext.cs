using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookingMeetingRoom.Models
{
    public partial class BookingMeetingRoomContext : IdentityDbContext<ApplicationUser>
    {
        public BookingMeetingRoomContext()
        {
        }

        public BookingMeetingRoomContext(DbContextOptions<BookingMeetingRoomContext> options)
            : base(options)
        {
        }

       
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<DayOfWeekMaster> DayOfWeekMasters { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<ImageRoom> ImageRooms { get; set; }
        public virtual DbSet<Objective> Objectives { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomAvailableBooking> RoomAvailableBookings { get; set; }
        public virtual DbSet<RoomFacility> RoomFacilities { get; set; }
        public virtual DbSet<RoomStatus> RoomStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-VS1TT45;Database=BookingMeetingRoom;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = Guid.NewGuid().ToString(), Name = "Member", NormalizedName = "MEMBER" }
                );

            modelBuilder.HasAnnotation("Relational:Collation", "Thai_CI_AS");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.ObjectiveId).HasColumnName("ObjectiveID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<DayOfWeekMaster>(entity =>
            {
                entity.HasKey(e => e.DayOfWeekId)
                    .HasName("PK_DayOfWeek");

                entity.ToTable("DayOfWeekMaster");

                entity.Property(e => e.DayOfWeekId).HasColumnName("DayOfWeekID");

                entity.Property(e => e.DayOfWeek).HasMaxLength(50);
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.HasKey(e => e.FacilitiesId);

                entity.Property(e => e.FacilitiesId).HasColumnName("FacilitiesID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FacilitiesName).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Floor>(entity =>
            {
                entity.ToTable("Floor");

                entity.Property(e => e.FloorId).HasColumnName("FloorID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FloorName).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ImageRoom>(entity =>
            {
                entity.ToTable("ImageRoom");

                entity.Property(e => e.ImageRoomId).HasColumnName("ImageRoomID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ImageName).HasMaxLength(100);

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Objective>(entity =>
            {
                entity.ToTable("Objective");

                entity.Property(e => e.ObjectiveId).HasColumnName("ObjectiveID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ObjectiveName).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.AvailableFrom)
                    .HasMaxLength(50)
                    .HasColumnName("Available_From");

                entity.Property(e => e.AvailableTo)
                    .HasMaxLength(50)
                    .HasColumnName("Available_To");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FloorId).HasColumnName("FloorID");

                entity.Property(e => e.ImageName).HasMaxLength(100);

                entity.Property(e => e.RoomName).HasMaxLength(100);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<RoomAvailableBooking>(entity =>
            {
                entity.ToTable("RoomAvailableBooking");

                entity.Property(e => e.RoomAvailableBookingId).HasColumnName("RoomAvailableBookingID");

                entity.Property(e => e.DayOfWeekId).HasColumnName("DayOfWeekID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");
            });

            modelBuilder.Entity<RoomFacility>(entity =>
            {
                entity.HasKey(e => e.RoomFacilitiesId);

                entity.Property(e => e.RoomFacilitiesId).HasColumnName("RoomFacilitiesID");

                entity.Property(e => e.FacilitiesId).HasColumnName("FacilitiesID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");
            });

            modelBuilder.Entity<RoomStatus>(entity =>
            {
                entity.ToTable("RoomStatus");

                entity.Property(e => e.RoomStatusId).HasColumnName("RoomStatusID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.StatusName).HasMaxLength(50);

                entity.Property(e => e.StatusType).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
