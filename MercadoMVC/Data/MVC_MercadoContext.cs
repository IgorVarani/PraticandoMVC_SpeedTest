using System;
using System.Collections.Generic;
using MVC_Mercado.Models;
using Microsoft.EntityFrameworkCore;

namespace MVC_Mercado.Data;

public partial class MVC_MercadoContext : DbContext
{
    public MVC_MercadoContext()
    {
    }

    public MVC_MercadoContext(DbContextOptions<MVC_MercadoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Inter_ItemUsuario> Inter_ItemUsuario { get; set; }

    public virtual DbSet<Item> Item { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MVC_Mercado;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inter_ItemUsuario>(entity =>
        {
            entity.HasKey(e => e.Inter_ItemUsuarioID).HasName("PK__Inter_It__5172E7B6639C9DBC");

            entity.HasOne(d => d.Item).WithMany(p => p.Inter_ItemUsuario)
                .HasForeignKey(d => d.ItemID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inter_Item");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Inter_ItemUsuario)
                .HasForeignKey(d => d.UsuarioID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inter_Usuario");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemID).HasName("PK__Item__727E83EB17A7CA5B");

            entity.Property(e => e.NomeItem).HasMaxLength(99);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioID).HasName("PK__Usuario__2B3DE798E418FEF8");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D1053448D60C15").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(99);
            entity.Property(e => e.NomeUsuario).HasMaxLength(99);
            entity.Property(e => e.Senha).HasMaxLength(32);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
