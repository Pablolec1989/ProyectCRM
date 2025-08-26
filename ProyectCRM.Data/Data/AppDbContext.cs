using Microsoft.EntityFrameworkCore;
using ProyectCRM.Models.Entities;

namespace ProyectCRM.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Archivo> Archivos { get; set; }
        public DbSet<TelefonoCliente> TelefonosClientes { get; set; }
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
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Seguimiento> Seguimientos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Area configuration
            modelBuilder.Entity<Area>().ToTable("Areas")
                .HasMany(a => a.Usuarios)
                .WithOne(u => u.Area)
                .HasForeignKey(u => u.AreaId);

            //AsuntoDeContacto configuration
            modelBuilder.Entity<AsuntoDeContacto>().ToTable("AsuntosDeContacto");

            //Rubro configuration
            modelBuilder.Entity<Rubro>().ToTable("Rubros")
                .HasMany(r => r.Empresas)
                .WithOne(e => e.Rubro)
                .HasForeignKey(e => e.RubroId);

            //Cliente configuration
            modelBuilder.Entity<Cliente>().ToTable("Clientes")
                .HasOne(c => c.Empresa)
                .WithOne(e => e.Cliente)
                .HasForeignKey<Empresa>(e => e.ClienteId);

            modelBuilder.Entity<Cliente>().ToTable("Clientes")
                .HasMany(c => c.Direcciones)
                .WithOne(d => d.Cliente)
                .HasForeignKey(d => d.ClienteId);
            
            modelBuilder.Entity<Cliente>().ToTable("Clientes")
                .HasMany(c => c.Telefonos)
                .WithOne(tc => tc.Cliente)
                .HasForeignKey(tc => tc.ClienteId);

            modelBuilder.Entity<Cliente>().ToTable("Clientes")
                .HasMany(c => c.Visitas)
                .WithOne(v => v.Cliente)
                .HasForeignKey(v => v.ClienteId);

            //CondicionIva configuration
            modelBuilder.Entity<CondicionIva>().ToTable("CondicionIva");

            //TipoTelefono configuration
            modelBuilder.Entity<TipoTelefono>().ToTable("TiposTelefono")
                .HasMany(tt => tt.TelefonosClientes)
                .WithOne(tc => tc.TipoTelefono)
                .HasForeignKey(tc => tc.TipoTelefonoId);

            //Empresa
            modelBuilder.Entity<Empresa>().ToTable("Empresas")
                .HasOne(e => e.Cliente)
                .WithOne(c => c.Empresa);

            modelBuilder.Entity<Empresa>().ToTable("Empresas");

            modelBuilder.Entity<Empresa>().ToTable("Empresas")
                .HasOne(e => e.Rubro)
                .WithMany(r => r.Empresas)
                .HasForeignKey(e => e.RubroId);

            //Llamado configuration
            modelBuilder.Entity<Llamado>().ToTable("Llamadas");

            modelBuilder.Entity<Llamado>().ToTable("Llamadas")
                .HasOne(l => l.Usuario)
                .WithMany(u => u.Llamados)
                .HasForeignKey(l => l.UsuarioId);

            modelBuilder.Entity<Llamado>().ToTable("Llamadas");

            //Mail configuration
            modelBuilder.Entity<Mail>().ToTable("Mails")
                .HasOne(m => m.Usuario)
                .WithMany(u => u.Mails)
                .HasForeignKey(m => m.UsuarioId);

            modelBuilder.Entity<Mail>().ToTable("Mails");

            //Rol configuration
            modelBuilder.Entity<Rol>().ToTable("Roles")
                .HasMany(r => r.Usuarios)
                .WithOne(u => u.Rol)
                .HasForeignKey(u => u.RolId);

            //Rubro configuration
            modelBuilder.Entity<Rubro>().ToTable("Rubros")
                .HasMany(r => r.Empresas)
                .WithOne(e => e.Rubro)
                .HasForeignKey(e => e.RubroId);

            //Seguimiento configuration
            modelBuilder.Entity<Seguimiento>().ToTable("Seguimientos")
                .HasOne(v => v.Usuario)
                .WithMany(u => u.Seguimientos)
                .HasForeignKey(v => v.UsuarioId);

            //TelefonoCliente configuration
            modelBuilder.Entity<TelefonoCliente>().ToTable("TelefonosClientes")
                .HasOne(tc => tc.TipoTelefono)
                .WithMany(tt => tt.TelefonosClientes)
                .HasForeignKey(tc => tc.TipoTelefonoId);

            //TipoDireccion configuration
            modelBuilder.Entity<TipoDireccion>().ToTable("TipoDireccion");

            //TipoTelefono configuration
            modelBuilder.Entity<TipoTelefono>().ToTable("TiposTelefono")
                .HasMany(tt => tt.TelefonosClientes)
                .WithOne(tc => tc.TipoTelefono)
                .HasForeignKey(tc => tc.TipoTelefonoId);

            //Usuario configuration
            modelBuilder.Entity<Usuario>().ToTable("Usuarios")
                .HasOne(u => u.Area)
                .WithMany(a => a.Usuarios)
                .HasForeignKey(u => u.AreaId);

            modelBuilder.Entity<Usuario>().ToTable("Usuarios")
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId);

            modelBuilder.Entity<Usuario>().ToTable("Usuarios")
                .HasMany(u => u.Llamados)
                .WithOne(l => l.Usuario)
                .HasForeignKey(l => l.UsuarioId);

            modelBuilder.Entity<Usuario>().ToTable("Usuarios")
                .HasMany(u => u.Mails)
                .WithOne(m => m.Usuario)
                .HasForeignKey(m => m.UsuarioId);

            modelBuilder.Entity<Usuario>().ToTable("Usuarios")
                .HasMany(u => u.Seguimientos)
                .WithOne(v => v.Usuario)
                .HasForeignKey(v => v.UsuarioId);

            modelBuilder.Entity<Usuario>().ToTable("Usuarios")
                .HasMany(u => u.VisitasUsuarios)
                .WithOne(vu => vu.Usuario)
                .HasForeignKey(vu => vu.UsuarioId);

            //Visita configuration
            modelBuilder.Entity<Visita>().ToTable("Visitas")
                .HasMany(v => v.Archivos)
                .WithOne(va => va.Visita)
                .HasForeignKey(va => va.VisitaId);

            modelBuilder.Entity<Visita>().ToTable("Visitas")
                .HasMany(v => v.VisitasUsuarios)
                .WithOne(vu => vu.Visita)
                .HasForeignKey(vu => vu.VisitaId);

            //VisitaArchivo configuration
            modelBuilder.Entity<Archivo>().ToTable("VisitasArchivos")
                .HasOne(va => va.Visita)
                .WithMany(v => v.Archivos)
                .HasForeignKey(va => va.VisitaId);

            //VisitaUsuario configuration
            modelBuilder.Entity<VisitaUsuario>().ToTable("VisitasUsuarios")
                .HasOne(vu => vu.Usuario)
                .WithMany(u => u.VisitasUsuarios)
                .HasForeignKey(vu => vu.UsuarioId);

            modelBuilder.Entity<VisitaUsuario>().ToTable("VisitasUsuarios")
                .HasOne(vu => vu.Visita)
                .WithMany(v => v.VisitasUsuarios)
                .HasForeignKey(vu => vu.VisitaId);


        }
    }
}
