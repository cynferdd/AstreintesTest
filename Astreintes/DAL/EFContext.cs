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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(local);Database=Astreintes;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public DbSet<Slot> Slots { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
