using Microsoft.EntityFrameworkCore;
using MotoFacil.Models;
using MotoFacil.Domain.Entities;

namespace MotoFacil.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Moto> Motos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureUserEntity(modelBuilder);
            ConfigureMotoEntity(modelBuilder);
        }

        private void ConfigureUserEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                      .HasColumnName("ID");

                entity.Property(e => e.Username)
                      .HasColumnName("USERNAME")
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Password)
                      .HasColumnName("PASSWORD")
                      .IsRequired()
                      .HasMaxLength(100);
            });
        }

        private void ConfigureMotoEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moto>(entity =>
            {
                entity.ToTable("MOTOS");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Placa)
                      .HasColumnName("PLACA")
                      .IsRequired()
                      .HasMaxLength(10);

                entity.Property(e => e.Modelo)
                      .HasColumnName("MODELO")
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Cor)
                      .HasColumnName("COR")
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(e => e.Categoria)
                      .HasColumnName("CATEGORIA")
                      .IsRequired()
                      .HasMaxLength(20);
            });
        }
    }
}
