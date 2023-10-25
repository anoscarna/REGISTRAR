using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace REGISTRAR.Models
{
    public partial class PERSONASContext : DbContext
    {
        public PERSONASContext()
        {
        }

        public PERSONASContext(DbContextOptions<PERSONASContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Persona> Personas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        optionsBuilder.UseSqlServer("Server=Localhost;DataBase=PERSONAS; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Documentoidentidad);

                entity.Property(e => e.Documentoidentidad).HasMaxLength(50);

                entity.Property(e => e.Apellidos).HasMaxLength(50);

                entity.Property(e => e.Correoelectronico)
                    .HasMaxLength(50)
                    .HasColumnName("correoelectronico");

                entity.Property(e => e.Correoelectronico2)
                    .HasMaxLength(50)
                    .HasColumnName("correoelectronico2");

                entity.Property(e => e.Direccionfisica1)
                    .HasMaxLength(100)
                    .HasColumnName("direccionfisica1");

                entity.Property(e => e.Direccionfisica2)
                    .HasMaxLength(100)
                    .HasColumnName("direccionfisica2");

                entity.Property(e => e.Fechadenacimiento).HasColumnType("date");

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.Property(e => e.Telefono1)
                    .HasMaxLength(20)
                    .HasColumnName("telefono1");

                entity.Property(e => e.Telefono2)
                    .HasMaxLength(20)
                    .HasColumnName("telefono2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
