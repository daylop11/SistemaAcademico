using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaAcademico.Data;
using SistemaAcademico.Models;

namespace SistemaAcademico.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly AppDbContext _context;
        public CalificacionesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var calificaciones = await _context.Calificaciones
                .Include(c => c.Estudiante)
                .Include(c => c.Curso)
                .ToListAsync();
            return View(calificaciones);
        }

        public IActionResult Create()
        {
            ViewBag.Estudientes = new SelectList(_context.Estudiantes, "EstudianteId", "Nombre");
            ViewBag.Cursos = new SelectList(_context.Cursos, "CursoId", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Calificacion> entityEntry = _context.Calificaciones.Add(calificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Estudientes = new SelectList(_context.Estudiantes, "EstudianteId", "Nombre", calificacion.EstudianteId);
            ViewBag.Cursos = new SelectList(_context.Cursos, "CursoId", "Nombre", calificacion.CursoId);
            return View(calificacion);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var calificacion = await _context.Calificaciones.FindAsync(id);
            if (calificacion == null) return NotFound();

            ViewBag.Estudientes = new SelectList(_context.Estudiantes, "EstudianteId", "Nombre", calificacion.EstudianteId);
            ViewBag.Cursos = new SelectList(_context.Cursos, "CursoId", "Nombre", calificacion.CursoId);
            return View(calificacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Calificacion calificacion)
        {
            if (id != calificacion.CalificacionId) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(calificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Estudientes = new SelectList(_context.Estudiantes, "EstudianteId", "Nombre", calificacion.EstudianteId);
            ViewBag.Cursos = new SelectList(_context.Cursos, "CursoId", "Nombre", calificacion.CursoId);
            return View(calificacion);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var calificacion = await _context.Calificaciones.FindAsync(id);
            if (calificacion == null) return NotFound();
            _context.Calificaciones.Remove(calificacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
