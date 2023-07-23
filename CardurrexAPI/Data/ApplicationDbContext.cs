using CardurrexAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CardurrexAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<Users>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //****************************************************
        //Criação das tabelas da BD
        //****************************************************
        public DbSet<BarbecueAttendees> BarbecueAttendees { get; set; }
        public DbSet<BarbecueAttendeesStatus> BarbecueAttendeesStatus { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<BarbecueGames> BarbecueGames { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<Barbecues> Barbecues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set the default schema for all entities to "dbo"
            modelBuilder.HasDefaultSchema("dbo");
             
            // Your other entity configurations, if any
        }
    }
}