using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaUniversitario.Data;
using SistemaUniversitario.Models;

namespace SistemaAcademico.Controllers
{
    public class DocentesController : Controller
    {
        private readonly AppDbContext _context;
        public DocentesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var docentes = await _context.Docentes.ToListAsync();
            return View(docentes);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Docente docente)
        {
            if (ModelState.IsValid)
            {
                _context.Docentes.Add(docente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(docente);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var docente = await _context.Docentes.FindAsync(id);
            if (docente == null) return NotFound();
            return View(docente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Docente docente)
        {
            if (id != docente.DocenteId) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(docente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(docente);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var docente = await _context.Docentes.FindAsync(id);
            if (docente == null) return NotFound();
            _context.Docentes.Remove(docente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
