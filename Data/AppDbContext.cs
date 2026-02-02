using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;
using SistemaUniversitario.Models;

namespace SistemaUniversitario.Data
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

            // Relaciones Matricula
            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Estudiante)
                .WithMany()
                .HasForeignKey(m => m.EstudianteId);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Curso)
                .WithMany()
                .HasForeignKey(m => m.CursoId);

            // Relaciones Calificacion
            modelBuilder.Entity<Calificacion>()
                .HasOne(c => c.Matricula)
                .WithMany()
                .HasForeignKey(c => c.MatriculaId);
        }
    }
}
