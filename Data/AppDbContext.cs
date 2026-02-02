using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;

namespace SistemaAcademico.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Estudiante)
                .WithMany(e => e.Matriculas)
                .HasForeignKey(m => m.EstudianteId);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Curso)
                .WithMany(c => c.Matriculas)
                .HasForeignKey(m => m.CursoId);

            modelBuilder.Entity<Calificacion>()
                .HasOne(c => c.Estudiante)
                .WithMany(e => e.Calificaciones)
                .HasForeignKey(c => c.EstudianteId);

            modelBuilder.Entity<Calificacion>()
                .HasOne(c => c.Curso)
                .WithMany(cu => cu.Calificaciones)
                .HasForeignKey(c => c.CursoId);
        }
    }
}
