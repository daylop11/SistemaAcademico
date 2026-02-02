using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaUniversitario.Data;
using SistemaUniversitario.Models;

namespace SistemaAcademico.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly AppDbContext _context;
        public EstudiantesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var estudiantes = await _context.Estudiantes.ToListAsync();
            return View(estudiantes);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Estudiantes.Add(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null) return NotFound();
            return View(estudiante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Estudiante estudiante)
        {
            if (id != estudiante.EstudianteId) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null) return NotFound();
            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
