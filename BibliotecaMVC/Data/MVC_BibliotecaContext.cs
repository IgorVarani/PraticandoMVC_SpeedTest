using System;
using System.Collections.Generic;
using BibliotecaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaMVC.Data;

public partial class MVC_BibliotecaContext : DbContext
{
    public MVC_BibliotecaContext()
    {
    }

    public MVC_BibliotecaContext(DbContextOptions<MVC_BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Inter_LivroUsuario> Inter_LivroUsuarios { get; set; }

    public virtual DbSet<Livro> Livros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MVC_Biblioteca;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inter_LivroUsuario>(entity =>
        {
            entity.HasKey(e => e.Inter_LivroUsuarioID).HasName("PK__Inter_Li__B5A567D36D0F09A0");

            entity.ToTable("Inter_LivroUsuario");

            entity.HasOne(d => d.Livro).WithMany(p => p.Inter_LivroUsuarios)
                .HasForeignKey(d => d.LivroID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inter_Livro");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Inter_LivroUsuarios)
                .HasForeignKey(d => d.UsuarioID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inter_Usuario");
        });

        modelBuilder.Entity<Livro>(entity =>
        {
            entity.HasKey(e => e.LivroID).HasName("PK__Livro__548655DDCDDAA833");

            entity.ToTable("Livro");

            entity.HasIndex(e => e.NomeLivro, "UQ__Livro__C8AFA001AAC4E034").IsUnique();

            entity.Property(e => e.NomeLivro).HasMaxLength(99);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioID).HasName("PK__Usuario__2B3DE798B3883774");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534526FE037").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(99);
            entity.Property(e => e.NomeUsuario).HasMaxLength(99);
            entity.Property(e => e.Senha).HasMaxLength(32);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
