using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Data
{
    public class EventCatalogContext: DbContext

    {public EventCatalogContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<EventType> EventTypes {get; set;}

        public DbSet<EventOrganizer> EventOrganizers {get; set;}

        public DbSet<EventItem> EventItems {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventType>(e =>
            {
                e.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
                e.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(100);
            });

            modelBuilder.Entity<EventOrganizer>(e =>
            {
                e.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
                e.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);
            });

            modelBuilder.Entity<EventItem>(e =>
            {
                e.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

                e.Property(t => t.Desc)
                .IsRequired()
                .HasMaxLength(500);

                e.Property(t => t.Price)
                .IsRequired();

                e.Property(t => t.Address)
                 .IsRequired();

                e.Property(t => t.City)
                .IsRequired();

                e.Property(t => t.State)
                .IsRequired();

                e.Property(t => t.EventStartDateTime)
                .IsRequired()
                .HasColumnType("DateTime");

                e.HasOne(t => t.EventOrganizer)
                .WithMany()
                .HasForeignKey(t => t.EventOrganizerId);

                e.HasOne(t => t.EventType)
                .WithMany()
                .HasForeignKey(t => t.EventTypeId);


            });
        }
    }
}
