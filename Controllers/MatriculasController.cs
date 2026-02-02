using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaUniversitario.Models;
using SistemaUniversitario.Data;

namespace SistemaAcademico.Controllers
{
    public class MatriculasController : Controller
    {
        private readonly AppDbContext _context;
        public MatriculasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var matriculas = await _context.Matriculas
                .Include(m => m.Estudiante)
                .Include(m => m.Curso)
                .ToListAsync();
            return View(matriculas);
        }

        public IActionResult Create()
        {
            ViewBag.Estudientes = new SelectList(_context.Estudiantes, "EstudianteId", "Nombre");
            ViewBag.Cursos = new SelectList(_context.Cursos, "CursoId", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                _context.Matriculas.Add(matricula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Estudientes = new SelectList(_context.Estudiantes, "EstudianteId", "Nombre", matricula.EstudianteId);
            ViewBag.Cursos = new SelectList(_context.Cursos, "CursoId", "Nombre", matricula.CursoId);
            return View(matricula);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula == null) return NotFound();
            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
