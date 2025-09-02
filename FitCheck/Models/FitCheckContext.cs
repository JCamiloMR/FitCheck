using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FitCheck.Models;

public partial class FitCheckContext : DbContext
{
    public FitCheckContext()
    {
    }

    public FitCheckContext(DbContextOptions<FitCheckContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07BD968454");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D1053495AFF59C").IsUnique();

            entity.HasIndex(e => e.Cedula, "UQ__Usuarios__B4ADFE380DEE7721").IsUnique();

            entity.Property(e => e.Cedula)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena).IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
