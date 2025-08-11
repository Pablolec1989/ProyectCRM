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
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<TipoDireccion> TiposDirecciones { get; set; }
        public DbSet<TipoTelefono> TiposTelefono { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Visita> Visitas { get; set; }
        public DbSet<Llamada> Llamadas { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<CondicionIva> IvaCondicion { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Area>().ToTable("Areas");
            modelBuilder.Entity<Rubro>().ToTable("Rubros");
            modelBuilder.Entity<AsuntoDeContacto>().ToTable("AsuntosDeContacto");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Direccion>().ToTable("Direcciones");
            modelBuilder.Entity<TipoDireccion>().ToTable("TiposDireccion");
            modelBuilder.Entity<TipoTelefono>().ToTable("TiposTelefono");
            modelBuilder.Entity<Rol>().ToTable("Roles");
            modelBuilder.Entity<Visita>().ToTable("Visitas");

            modelBuilder.Entity<VisitasUsuarios>()
                .HasKey(vu => new { vu.VisitaId, vu.UsuarioId });
            modelBuilder.Entity<VisitasUsuarios>()
                .HasOne(vu => vu.Visita)
                .WithMany(v => v.VisitasUsuarios)
                .HasForeignKey(vu => vu.VisitaId);
            modelBuilder.Entity<VisitasUsuarios>()
                .HasOne(vu => vu.Usuario)
                .WithMany(u => u.VisitasUsuarios)
                .HasForeignKey(vu => vu.UsuarioId);

            modelBuilder.Entity<Llamada>().ToTable("Llamadas");
            modelBuilder.Entity<Mail>().ToTable("Mails");
            modelBuilder.Entity<CondicionIva>().ToTable("IvaCondicion");

        }
    }
}
