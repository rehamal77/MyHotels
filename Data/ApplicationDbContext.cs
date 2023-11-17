using Microsoft.EntityFrameworkCore;
using MyHotels.Models;

namespace MyHotels.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
    
        {
           
        }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<RoomDetails> RoomDetails { get; set; }

    }
}
