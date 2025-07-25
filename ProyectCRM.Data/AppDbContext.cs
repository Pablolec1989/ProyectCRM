using Microsoft.EntityFrameworkCore;
using ProyectCRM.Models;

namespace ProyectCRM.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Area> Area { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>().HasKey(a => a.id);
            modelBuilder.Entity<Area>()
                .Property(a => a.nombre)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
