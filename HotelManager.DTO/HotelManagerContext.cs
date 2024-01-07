using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HotelManager.DTO
{
    public partial class HotelManagerContext : DbContext
    {
        public HotelManagerContext()
            : base("name=HotelManagerContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<TypeRoom> TypeRooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Room)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeRoom>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.TypeRoom1)
                .HasForeignKey(e => e.typeRoom)
                .WillCascadeOnDelete(false);
        }
    }
}
