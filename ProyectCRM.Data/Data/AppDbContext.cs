using Microsoft.EntityFrameworkCore;
using ProyectCRM.Models.Entities;

namespace ProyectCRM.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<AsuntoDeContacto> AsuntosDeContacto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Area>().ToTable("Areas");
            modelBuilder.Entity<Rubro>().ToTable("Rubros");
            modelBuilder.Entity<AsuntoDeContacto>().ToTable("AsuntosDeContacto");
        }
    }
}
