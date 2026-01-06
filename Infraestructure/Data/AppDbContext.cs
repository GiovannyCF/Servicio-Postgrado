using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Diplomado> Diplomados { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Nota> Notas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Diplomado>().Property(p => p.Costo).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Nota>().Property(p => p.Valor).HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Nota>()
                .HasOne(n => n.Modulo)
                .WithMany()
                .HasForeignKey(n => n.ModuloId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Nota>()
                .HasOne(n => n.Inscripcion)
                .WithMany()
                .HasForeignKey(n => n.InscripcionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}