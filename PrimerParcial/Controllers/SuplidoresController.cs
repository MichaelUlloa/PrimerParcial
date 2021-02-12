using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrimerParcial.Data;
using PrimerParcial.Models;

namespace PrimerParcial.Controllers
{
    public class SuplidoresController : Controller
    {
        private readonly ParcialDbContext _context;

        public SuplidoresController(ParcialDbContext context)
        {
            _context = context;
        }

        // GET: Suplidores
        public async Task<IActionResult> Index()
        {
            var parcialDbContext = _context.Suplidores.Include(s => s.Clasificacion);
            return View(await parcialDbContext.ToListAsync());
        }

        // GET: Suplidores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suplidores = await _context.Suplidores
                .Include(s => s.Clasificacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suplidores == null)
            {
                return NotFound();
            }

            return View(suplidores);
        }

        // GET: Suplidores/Create
        public IActionResult Create()
        {
            ViewData["ClasificacionId"] = new SelectList(_context.ClasificacionSuplidores, "Id", "Id");
            return View();
        }

        // POST: Suplidores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ClasificacionId")] Suplidores suplidores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suplidores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClasificacionId"] = new SelectList(_context.ClasificacionSuplidores, "Id", "Id", suplidores.ClasificacionId);
            return View(suplidores);
        }

        // GET: Suplidores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suplidores = await _context.Suplidores.FindAsync(id);
            if (suplidores == null)
            {
                return NotFound();
            }
            ViewData["ClasificacionId"] = new SelectList(_context.ClasificacionSuplidores, "Id", "Id", suplidores.ClasificacionId);
            return View(suplidores);
        }

        // POST: Suplidores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ClasificacionId")] Suplidores suplidores)
        {
            if (id != suplidores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suplidores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuplidoresExists(suplidores.Id))
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
            ViewData["ClasificacionId"] = new SelectList(_context.ClasificacionSuplidores, "Id", "Id", suplidores.ClasificacionId);
            return View(suplidores);
        }

        // GET: Suplidores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suplidores = await _context.Suplidores
                .Include(s => s.Clasificacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suplidores == null)
            {
                return NotFound();
            }

            return View(suplidores);
        }

        // POST: Suplidores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suplidores = await _context.Suplidores.FindAsync(id);
            _context.Suplidores.Remove(suplidores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuplidoresExists(int id)
        {
            return _context.Suplidores.Any(e => e.Id == id);
        }
    }
}
