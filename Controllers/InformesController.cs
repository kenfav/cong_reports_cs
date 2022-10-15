using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CongReports.Models;

namespace CongReports.Controllers
{
    public class InformesController : Controller
    {
        private readonly InformesContext _context;

        public InformesController(InformesContext context)
        {
            _context = context;
        }

        // GET: Informes
        public async Task<IActionResult> Index()
        {
            var informesContext = _context.Informe.Include(i => i.Publicador);
            return View(await informesContext.ToListAsync());
        }

        // GET: Informes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Informe == null)
            {
                return NotFound();
            }

            var informe = await _context.Informe
                .Include(i => i.Publicador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (informe == null)
            {
                return NotFound();
            }

            return View(informe);
        }

        // GET: Informes/Create
        public IActionResult Create()
        {
            ViewData["PublicadorId"] = new SelectList(_context.Set<Publicador>(), "Id", "Id");
            return View();
        }

        // POST: Informes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PublicadorId,Publicaciones,Videos,Horas,Revisitas,Estudios,Notas,PrecursorAuxiliar")] Informe informe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(informe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PublicadorId"] = new SelectList(_context.Set<Publicador>(), "Id", "Id", informe.PublicadorId);
            return View(informe);
        }

        // GET: Informes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Informe == null)
            {
                return NotFound();
            }

            var informe = await _context.Informe.FindAsync(id);
            if (informe == null)
            {
                return NotFound();
            }
            ViewData["PublicadorId"] = new SelectList(_context.Set<Publicador>(), "Id", "Id", informe.PublicadorId);
            return View(informe);
        }

        // POST: Informes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PublicadorId,Publicaciones,Videos,Horas,Revisitas,Estudios,Notas,PrecursorAuxiliar")] Informe informe)
        {
            if (id != informe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(informe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InformeExists(informe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PublicadorId"] = new SelectList(_context.Set<Publicador>(), "Id", "Id", informe.PublicadorId);
            return View(informe);
        }

        // GET: Informes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Informe == null)
            {
                return NotFound();
            }

            var informe = await _context.Informe
                .Include(i => i.Publicador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (informe == null)
            {
                return NotFound();
            }

            return View(informe);
        }

        // POST: Informes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Informe == null)
            {
                return Problem("Entity set 'InformesContext.Informe'  is null.");
            }
            var informe = await _context.Informe.FindAsync(id);
            if (informe != null)
            {
                _context.Informe.Remove(informe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InformeExists(int id)
        {
          return (_context.Informe?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
