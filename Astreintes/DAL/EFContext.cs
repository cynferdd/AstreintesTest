using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class EFContext : DbContext
    {
        public EFContext()
        {

        }

        /// <summary>
        /// Configuring Entity framework with a connection string
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(local);Database=Astreintes;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        /// <summary>
        /// DBSet for slots
        /// </summary>
        public DbSet<Slot> Slots { get; set; }

        /// <summary>
        /// DBSet for users
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}
