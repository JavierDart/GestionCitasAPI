using GestionCitasAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace GestionCitasAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Artistas> Artistas { get; set; }
        public DbSet<Tatuajes> Tatuajes { get; set; }
        public DbSet<Citas> Citas { get; set; } 
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<CatTatuajes> CatTatuajes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("IdCliente");

                entity.Property(e => e.FechaRegistro)
                      .HasDefaultValueSql("GETDATE()")
                      .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Artistas>(entity =>
            {
                entity.HasKey(e =>e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("IdArtista");
            });

            modelBuilder.Entity<Tatuajes>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("IdTatuaje");
            });

            modelBuilder.Entity<Citas>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("IdCita");
                entity.Property(e => e.Duracion)
                      .HasColumnName("DuracionHoras");
            });

            modelBuilder.Entity<Pagos>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("IdPago");
            });

            modelBuilder.Entity<CatTatuajes>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("IdCategoria");

                entity.ToTable("CategoriasTatuajes");
            });

        }
    }
}
