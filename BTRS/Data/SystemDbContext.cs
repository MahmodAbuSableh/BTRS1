using BTRS.Models;
using Microsoft.EntityFrameworkCore;

namespace BTRS.Data
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Passenger> Passengers { set; get; }
        public DbSet<Trip> Trips { set; get; }
        public DbSet<Buss> Buses { set; get; }
        public DbSet<Admin> Admins { set; get; }
       

        public DbSet<Passengers_Trips> passenger_trip { set; get; }

    }
}
