using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ProyectCRM.Models.Entities;

namespace ProyectCRM.Models.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Archivo> Archivos { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<AsuntosDeContacto> AsuntosDeContactos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<CondicionIva> CondicionIvas { get; set; }

    public virtual DbSet<Direccion> Direcciones { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Llamado> Llamados { get; set; }

    public virtual DbSet<Mail> Mails { get; set; }

    public virtual DbSet<Rol> Roles { get; set; }

    public virtual DbSet<Rubro> Rubros { get; set; }

    public virtual DbSet<Seguimiento> Seguimientos { get; set; }

    public virtual DbSet<Telefono> Telefonos { get; set; }

    public virtual DbSet<TipoDireccion> TipoDirecciones { get; set; }

    public virtual DbSet<TiposTelefono> TiposTelefonos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Visita> Visitas { get; set; }

    public virtual DbSet<VisitaUsuario> VisitaUsuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-WSB\\SQLEXPRESS;Database=CRM_Project_Ver2;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Area");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasMany(e => e.Llamados).WithOne(l => l.Area)
            .HasForeignKey(l => l.AreaId)
            .OnDelete(DeleteBehavior.SetNull);
            
            entity.HasMany(e => e.Mails).WithOne(m => m.Area)
            .HasForeignKey(m => m.AreaId)
            .OnDelete(DeleteBehavior.ClientSetNull);
            
            entity.HasMany(e => e.Seguimientos).WithOne(s => s.Area)
            .HasForeignKey(s => s.AreaId)
            .OnDelete(DeleteBehavior.SetNull);
            
            entity.HasMany(e => e.Usuarios).WithOne(u => u.Area)
            .HasForeignKey(u => u.AreaId)
            .OnDelete(DeleteBehavior.SetNull);

        });

        modelBuilder.Entity<AsuntosDeContacto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MotivosDeContacto");

            entity.ToTable("AsuntosDeContacto");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Apellido).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(20);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK_Clientes_Empresas");
        });

        modelBuilder.Entity<CondicionIva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CondicionFrenteIVA");

            entity.ToTable("CondicionIva");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Calle).HasMaxLength(150);
            entity.Property(e => e.Ciudad).HasMaxLength(150);
            entity.Property(e => e.CodigoPostal).HasMaxLength(50);
            entity.Property(e => e.Provincia).HasMaxLength(150);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Direcciones)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_Direcciones_Clientes");

            entity.HasOne(d => d.TipoDireccion).WithMany(p => p.Direcciones)
                .HasForeignKey(d => d.TipoDireccionId)
                .HasConstraintName("FK_Direcciones_TiposDirecciones");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Cuil)
                .HasMaxLength(50)
                .HasColumnName("CUIL");
            entity.Property(e => e.Cuit)
                .HasMaxLength(50)
                .HasColumnName("CUIT");
            entity.Property(e => e.CondicionIvaId).HasColumnName("CondicionIva");
            entity.Property(e => e.RazonSocial).HasMaxLength(200);

            entity.HasOne(d => d.CondicionIva).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.CondicionIvaId)
                .HasConstraintName("FK_Empresas_CondicionIva");

            entity.HasOne(d => d.Rubro).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.RubroId)
                .HasConstraintName("FK_Empresas_Rubros");
        });

        modelBuilder.Entity<Llamado>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Detalle).HasMaxLength(300);
            entity.Property(e => e.FechaLlamado).HasColumnType("datetime");

            entity.HasOne(d => d.Area).WithMany(p => p.Llamados)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Llamadas_Areas");

            entity.HasOne(d => d.AsuntoDeContacto).WithMany(p => p.Llamados)
                .HasForeignKey(d => d.AsuntoDeContactoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Llamadas_AsuntosDeContacto");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Llamados)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Llamadas_Clientes");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Llamados)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Llamadas_Usuarios");
        });

        modelBuilder.Entity<Mail>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Detalle).HasMaxLength(200);
            entity.Property(e => e.FechaMail).HasColumnType("datetime");

            entity.HasOne(m => m.Area).WithMany(a => a.Mails)
                .HasForeignKey(m => m.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mails_Areas");

            entity.HasOne(d => d.AsuntoDeContacto).WithMany(p => p.Mail)
                .HasForeignKey(d => d.AsuntoDeContactoId)
                .HasConstraintName("FK_Mails_Asuntos");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Mails)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_Mails_Clientes");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Mails)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Mails_UsuarioDestino");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Rubro>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(200);
        });

        modelBuilder.Entity<Seguimiento>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Detalle).HasMaxLength(300);
            entity.Property(e => e.Titulo).HasMaxLength(50);

            entity.HasOne(d => d.Area)
                .WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Seguimientos_Areas");

            entity.HasOne(s => s.Area)
                .WithMany(a => a.Seguimientos)
                .HasForeignKey(s => s.AreaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Seguimientos_Areas");

            entity.HasOne(d => d.Usuario)
                .WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Seguimientos_Usuarios");
        });

        modelBuilder.Entity<Telefono>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Numero).HasMaxLength(50);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Telefonos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_Telefonos_Clientes");

            entity.HasOne(d => d.TipoTelefono).WithMany(p => p.TelefonosClientes)
                .HasForeignKey(d => d.TipoTelefonoId)
                .HasConstraintName("FK_Telefonos_TiposTelefono");
        });

        modelBuilder.Entity<TipoDireccion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TiposDirecciones");

            entity.ToTable("TipoDireccion");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<TiposTelefono>(entity =>
        {
            entity.ToTable("TiposTelefono");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);

            entity.HasOne(d => d.Area).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK_Usuarios_Areas");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK_Usuarios_Roles");
        });

        modelBuilder.Entity<Visita>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Observaciones).HasMaxLength(200);

            entity.HasOne(d => d.Direccion).WithMany(p => p.Visitas)
                .HasForeignKey(d => d.DireccionId)
                .HasConstraintName("FK_Visitas_Direcciones");
        });

        modelBuilder.Entity<VisitaUsuario>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioId, e.VisitaId })
                  .HasName("PK_VisitaUsuario");

            entity.ToTable("VisitaUsuario");

            // Configuración de la relación con Usuario
            entity.HasOne(d => d.Usuario)
                  .WithMany(p => p.VisitasUsuarios!)
                  .HasForeignKey(d => d.UsuarioId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_VisitaUsuario_Usuario");

            // Configuración de la relación con Visita
            entity.HasOne(vu => vu.Visita)
                .WithMany(v => v.VisitasUsuarios)
                .HasForeignKey(vu => vu.VisitaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_VisitaUsuario_Visita");
        });

        modelBuilder.Entity<Archivo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Archivos");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.NombreArchivo).HasMaxLength(100);
            entity.Property(e => e.RutaArchivo).HasMaxLength(100);

            entity.HasOne(d => d.Visita).WithMany(p => p.Archivos)
                .HasForeignKey(d => d.VisitaId)
                .HasConstraintName("FK_Archivos_Visitas");
        });
    }
}
