using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WindowsFormsApp3
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model12")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<customerRoom> customerRooms { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<staffRoom> staffRooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.customerName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.customerType)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.customerRooms)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.roomType)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.roomSize)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.maintenanceState)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.cleaningState)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.reservationState)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.customerRooms)
                .WithRequired(e => e.Room)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Staffs)
                .WithMany(e => e.Rooms)
                .Map(m => m.ToTable("StaffRoom", "Hotel_Services").MapLeftKey("roomId").MapRightKey("staffId"));

            modelBuilder.Entity<Staff>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.position)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.departmentType)
                .IsUnicode(false);
            modelBuilder.Entity<Staff>()
              .Property(e => e.image)
              .IsUnicode(false);
        }
    }
}
