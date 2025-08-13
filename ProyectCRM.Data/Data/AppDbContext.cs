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
        public DbSet<Llamado> Llamadas { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<CondicionIva> CondicionIva { get; set; }
        public DbSet<VisitaUsuario> VisitasUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Area>().ToTable("Areas");
            modelBuilder.Entity<Rubro>().ToTable("Rubros");
            modelBuilder.Entity<AsuntoDeContacto>().ToTable("AsuntosDeContacto");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");

            modelBuilder.Entity<Direccion>().ToTable("Direcciones")
                .HasOne(d => d.TipoDireccion)
                .WithMany()
                .HasForeignKey(d => d.TipoDireccionId);

            modelBuilder.Entity<TipoDireccion>().ToTable("TiposDireccion");
            modelBuilder.Entity<TipoTelefono>().ToTable("TiposTelefono");
            modelBuilder.Entity<CondicionIva>().ToTable("CondicionIva");
            modelBuilder.Entity<Rol>().ToTable("Roles");

            modelBuilder.Entity<Visita>().ToTable("Visitas")
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Visitas)
                .HasForeignKey(v => v.ClienteId);

            modelBuilder.Entity<Visita>()
                .HasOne(v => v.Direccion)
                .WithMany(d => d.Visitas)
                .HasForeignKey(v => v.DireccionId);

            modelBuilder.Entity<VisitaUsuario>()
                .HasKey(vu => new { vu.VisitaId, vu.UsuarioId });

            modelBuilder.Entity<VisitaUsuario>()
                .HasOne(vu => vu.Visita)
                .WithMany(v => v.VisitasUsuarios)
                .HasForeignKey(vu => vu.VisitaId);

            modelBuilder.Entity<VisitaUsuario>()
                .HasOne(vu => vu.Usuario)
                .WithMany(u => u.VisitasUsuarios)
                .HasForeignKey(vu => vu.UsuarioId);

            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId);

            modelBuilder.Entity<Llamado>().ToTable("Llamadas");
            modelBuilder.Entity<Mail>().ToTable("Mails");

        }
    }
}
