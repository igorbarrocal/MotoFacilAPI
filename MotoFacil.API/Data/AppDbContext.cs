using Microsoft.EntityFrameworkCore;
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

                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id)
                      .HasColumnName("ID");

                entity.Property(u => u.Username)
                      .HasColumnName("Username")
                      .IsRequired()
                      .HasMaxLength(100);

               
            });
        }

        private void ConfigureMotoEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moto>(entity =>
            {
                entity.ToTable("MOTOS");

                entity.HasKey(m => m.Id);
                entity.Property(m => m.Id)
                      .HasColumnName("ID");

                entity.Property(m => m.Placa)
                      .HasColumnName("PLACA")
                      .IsRequired()
                      .HasMaxLength(20);

                
            });
        }
    }
}
