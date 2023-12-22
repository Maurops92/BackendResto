using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Test_back.Modelos;

public partial class RestocrudContext : DbContext
{
    public RestocrudContext()
    {
    }

    public RestocrudContext(DbContextOptions<RestocrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ceo> Ceos { get; set; }

    public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }

    public virtual DbSet<Gerente> Gerentes { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<Mozo> Mozos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=RESTOCRUD.mssql.somee.com;Initial Catalog=RESTOCRUD;user id=Maurops_SQLLogin_1;pwd=bzjzj19by8;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ceo>(entity =>
        {
            entity.HasKey(e => e.Ceoid).HasName("PK__CEO__5D8217436A693392");

            entity.ToTable("CEO");

            entity.Property(e => e.Ceoid)
                .ValueGeneratedNever()
                .HasColumnName("CEOID");
            entity.Property(e => e.IsActive).HasDefaultValue(1);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RolId).HasColumnName("RolID");

            entity.HasOne(d => d.Rol).WithMany(p => p.Ceos)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CEO__RolID__2B3F6F97");
        });

        modelBuilder.Entity<DetalleVentum>(entity =>
        {
            entity.HasKey(e => new { e.VentaId, e.MenuId }).HasName("PK__DETALLE___47D8BC69A480D92C");

            entity.ToTable("DETALLE_VENTA");

            entity.Property(e => e.VentaId).HasColumnName("VentaID");
            entity.Property(e => e.MenuId).HasColumnName("MenuID");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Menu).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_V__MenuI__403A8C7D");

            entity.HasOne(d => d.Venta).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.VentaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_V__Venta__3F466844");
        });

        modelBuilder.Entity<Gerente>(entity =>
        {
            entity.HasKey(e => e.GerenteId).HasName("PK__GERENTES__64E13472F4EF1238");

            entity.ToTable("GERENTES");

            entity.Property(e => e.GerenteId)
                .ValueGeneratedNever()
                .HasColumnName("GerenteID");
            entity.Property(e => e.IsActive).HasDefaultValue(1);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RolId).HasColumnName("RolID");

            entity.HasOne(d => d.Rol).WithMany(p => p.Gerentes)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GERENTES__RolID__276EDEB3");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__MENU__C99ED250A5C18D2A");

            entity.ToTable("MENU");

            entity.Property(e => e.MenuId)
                .ValueGeneratedNever()
                .HasColumnName("MenuID");
            entity.Property(e => e.IsActive).HasDefaultValue(1);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.MesaId).HasName("PK__MESAS__6A4196C82224C6D3");

            entity.ToTable("MESAS");

            entity.Property(e => e.MesaId)
                .ValueGeneratedNever()
                .HasColumnName("MesaID");
            entity.Property(e => e.IsOccupied).HasDefaultValue(0);
            entity.Property(e => e.MozoId).HasColumnName("MozoID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Mozo).WithMany(p => p.Mesas)
                .HasForeignKey(d => d.MozoId)
                .HasConstraintName("FK__MESAS__MozoID__3C69FB99");
        });

        modelBuilder.Entity<Mozo>(entity =>
        {
            entity.HasKey(e => e.MozoId).HasName("PK__MOZOS__A01CDF5C4FC7A688");

            entity.ToTable("MOZOS");

            entity.Property(e => e.MozoId)
                .ValueGeneratedNever()
                .HasColumnName("MozoID");
            entity.Property(e => e.IsActive).HasDefaultValue(1);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.TurnoId).HasColumnName("TurnoID");

            entity.HasOne(d => d.Rol).WithMany(p => p.Mozos)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MOZOS__RolID__33D4B598");

            entity.HasOne(d => d.Turno).WithMany(p => p.Mozos)
                .HasForeignKey(d => d.TurnoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MOZOS__TurnoID__34C8D9D1");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__ROL__F92302D1C9FC0871");

            entity.ToTable("ROL");

            entity.Property(e => e.RolId)
                .ValueGeneratedNever()
                .HasColumnName("RolID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.RolName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.TurnoId).HasName("PK__TURNOS__AD3E2EB4CA9AABB7");

            entity.ToTable("TURNOS");

            entity.Property(e => e.TurnoId)
                .ValueGeneratedNever()
                .HasColumnName("TurnoID");
            entity.Property(e => e.TurnoName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.VentaId).HasName("PK__VENTAS__5B41514CAF98D370");

            entity.ToTable("VENTAS");

            entity.Property(e => e.VentaId)
                .ValueGeneratedNever()
                .HasColumnName("VentaID");
            entity.Property(e => e.MozoId).HasColumnName("MozoID");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Mozo).WithMany(p => p.Venta)
                .HasForeignKey(d => d.MozoId)
                .HasConstraintName("FK__VENTAS__MozoID__37A5467C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
