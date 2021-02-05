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
    public class ArticulosController : Controller
    {
        private readonly ParcialDbContext _context;

        public ArticulosController(ParcialDbContext context)
        {
            _context = context;
        }

        // GET: Articulos
        public async Task<IActionResult> Index()
        {
            var parcialDbContext = _context.Articulos.Include(a => a.Clasificacion).Include(a => a.Suplidor);
            return View(await parcialDbContext.ToListAsync());
        }

        // GET: Articulos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulos = await _context.Articulos
                .Include(a => a.Clasificacion)
                .Include(a => a.Suplidor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articulos == null)
            {
                return NotFound();
            }

            return View(articulos);
        }

        // GET: Articulos/Create
        public IActionResult Create()
        {
            ViewData["Clasificacion_ArticulosId"] = new SelectList(_context.Clasificacion_Articulos, "Id", "Id");
            ViewData["SuplidorId"] = new SelectList(_context.Set<Suplidores>(), "Id", "Id");
            return View();
        }

        // POST: Articulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,SuplidorId,Clasificacion_ArticulosId")] Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articulos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Clasificacion_ArticulosId"] = new SelectList(_context.Clasificacion_Articulos, "Id", "Id", articulos.Clasificacion_ArticulosId);
            ViewData["SuplidorId"] = new SelectList(_context.Set<Suplidores>(), "Id", "Id", articulos.SuplidorId);
            return View(articulos);
        }

        // GET: Articulos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulos = await _context.Articulos.FindAsync(id);
            if (articulos == null)
            {
                return NotFound();
            }
            ViewData["Clasificacion_ArticulosId"] = new SelectList(_context.Clasificacion_Articulos, "Id", "Id", articulos.Clasificacion_ArticulosId);
            ViewData["SuplidorId"] = new SelectList(_context.Set<Suplidores>(), "Id", "Id", articulos.SuplidorId);
            return View(articulos);
        }

        // POST: Articulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,SuplidorId,Clasificacion_ArticulosId")] Articulos articulos)
        {
            if (id != articulos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articulos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticulosExists(articulos.Id))
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
            ViewData["Clasificacion_ArticulosId"] = new SelectList(_context.Clasificacion_Articulos, "Id", "Id", articulos.Clasificacion_ArticulosId);
            ViewData["SuplidorId"] = new SelectList(_context.Set<Suplidores>(), "Id", "Id", articulos.SuplidorId);
            return View(articulos);
        }

        // GET: Articulos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulos = await _context.Articulos
                .Include(a => a.Clasificacion)
                .Include(a => a.Suplidor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articulos == null)
            {
                return NotFound();
            }

            return View(articulos);
        }

        // POST: Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articulos = await _context.Articulos.FindAsync(id);
            _context.Articulos.Remove(articulos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticulosExists(int id)
        {
            return _context.Articulos.Any(e => e.Id == id);
        }
    }
}
