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
    public class Clasificacion_SuplidoresController : Controller
    {
        private readonly ParcialDbContext _context;

        public Clasificacion_SuplidoresController(ParcialDbContext context)
        {
            _context = context;
        }

        // GET: Clasificacion_Suplidores
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClasificacionSuplidores.ToListAsync());
        }

        // GET: Clasificacion_Suplidores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacion_Suplidores = await _context.ClasificacionSuplidores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clasificacion_Suplidores == null)
            {
                return NotFound();
            }

            return View(clasificacion_Suplidores);
        }

        // GET: Clasificacion_Suplidores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clasificacion_Suplidores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Clasificacion")] Clasificacion_Suplidores clasificacion_Suplidores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clasificacion_Suplidores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clasificacion_Suplidores);
        }

        // GET: Clasificacion_Suplidores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacion_Suplidores = await _context.ClasificacionSuplidores.FindAsync(id);
            if (clasificacion_Suplidores == null)
            {
                return NotFound();
            }
            return View(clasificacion_Suplidores);
        }

        // POST: Clasificacion_Suplidores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Clasificacion")] Clasificacion_Suplidores clasificacion_Suplidores)
        {
            if (id != clasificacion_Suplidores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clasificacion_Suplidores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Clasificacion_SuplidoresExists(clasificacion_Suplidores.Id))
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
            return View(clasificacion_Suplidores);
        }

        // GET: Clasificacion_Suplidores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacion_Suplidores = await _context.ClasificacionSuplidores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clasificacion_Suplidores == null)
            {
                return NotFound();
            }

            return View(clasificacion_Suplidores);
        }

        // POST: Clasificacion_Suplidores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clasificacion_Suplidores = await _context.ClasificacionSuplidores.FindAsync(id);
            _context.ClasificacionSuplidores.Remove(clasificacion_Suplidores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Clasificacion_SuplidoresExists(int id)
        {
            return _context.ClasificacionSuplidores.Any(e => e.Id == id);
        }
    }
}
