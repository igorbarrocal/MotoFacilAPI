
using Microsoft.EntityFrameworkCore;
using MotoFacil.Models;

namespace MotoFacil.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        // Opcional: configurações manuais de mapeamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS"); // Nome da tabela no Oracle

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
    }
}
