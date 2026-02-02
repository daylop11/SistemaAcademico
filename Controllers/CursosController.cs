using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaUniversitario.Data;
using SistemaUniversitario.Models;

namespace SistemaAcademico.Controllers
{
    public class CursosController : Controller
    {
        private readonly AppDbContext _context;
        public CursosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cursos = await _context.Cursos.Include(c => c.Docente).ToListAsync();
            return View(cursos);
        }

        public IActionResult Create()
        {
            ViewBag.Docentes = _context.Docentes.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Cursos.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Docentes = _context.Docentes.ToList();
            return View(curso);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null) return NotFound();
            ViewBag.Docentes = _context.Docentes.ToList();
            return View(curso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Curso curso)
        {
            if (id != curso.CursoId) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Docentes = _context.Docentes.ToList();
            return View(curso);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null) return NotFound();
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
