using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Music_Events.Models;

namespace Music_Events.Data
{
    public class EventsContext : DbContext
    {
        public EventsContext (DbContextOptions<EventsContext> options)
            : base(options)
        {
        }

        public DbSet<Music_Events.Models.Artist> Artists { get; set; }

        public DbSet<Music_Events.Models.Booking> Bookings { get; set; }
        public DbSet<Music_Events.Models.Event> Events { get; set; }
        public DbSet<Music_Events.Models.Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().ToTable("Artist");
            modelBuilder.Entity<Booking>().ToTable("Booking");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Track>().ToTable("Track");
        }
    }
}
