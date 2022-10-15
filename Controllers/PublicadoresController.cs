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
    public class PublicadoresController : Controller
    {
        private readonly CongReportsContext _context;

        public PublicadoresController(CongReportsContext context)
        {
            _context = context;
        }

        // GET: Publicadores
        public async Task<IActionResult> Index()
        {
            return _context.Publicador != null ?
                        View(await _context.Publicador.ToListAsync()) :
                        Problem("Entity set 'CongReportsContext.Publicador'  is null.");
        }

        // GET: Publicadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Publicador == null)
            {
                return NotFound();
            }

            var publicador = await _context.Publicador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publicador == null)
            {
                return NotFound();
            }

            return View(publicador);
        }

        // GET: Publicadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publicadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,FechaNacimiento,FechaBautismo,EsUngido,EsAnciano,EsSiervoMinisterial,EsPrecursor")] Publicador publicador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publicador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publicador);
        }

        // GET: Publicadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Publicador == null)
            {
                return NotFound();
            }

            var publicador = await _context.Publicador.FindAsync(id);
            if (publicador == null)
            {
                return NotFound();
            }
            return View(publicador);
        }

        // POST: Publicadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,FechaNacimiento,FechaBautismo,EsUngido,EsAnciano,EsSiervoMinisterial,EsPrecursor")] Publicador publicador)
        {
            if (id != publicador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicadorExists(publicador.Id))
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
            return View(publicador);
        }

        // GET: Publicadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Publicador == null)
            {
                return NotFound();
            }

            var publicador = await _context.Publicador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publicador == null)
            {
                return NotFound();
            }

            return View(publicador);
        }

        // POST: Publicadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Publicador == null)
            {
                return Problem("Entity set 'CongReportsContext.Publicador'  is null.");
            }
            var publicador = await _context.Publicador.FindAsync(id);
            if (publicador != null)
            {
                _context.Publicador.Remove(publicador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicadorExists(int id)
        {
            return (_context.Publicador?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
