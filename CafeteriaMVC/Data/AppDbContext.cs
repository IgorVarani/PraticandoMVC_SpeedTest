using System;
using System.Collections.Generic;
using CafeteriaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaMVC.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Inter_ItemUsuario> Inter_ItemUsuario { get; set; }

    public virtual DbSet<Item> Item { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inter_ItemUsuario>(entity =>
        {
            entity.HasKey(e => e.Inter_ItemUsuarioID).HasName("PK__Inter_It__5172E7B6EF58EE29");

            entity.HasOne(d => d.Item).WithMany(p => p.Inter_ItemUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inter_Item");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Inter_ItemUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inter_Usuario");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemID).HasName("PK__Item__727E83EB21E04C67");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioID).HasName("PK__Usuario__2B3DE798BC46B99B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
