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
    public class Clasificacion_ArticulosController : Controller
    {
        private readonly ParcialDbContext _context;

        public Clasificacion_ArticulosController(ParcialDbContext context)
        {
            _context = context;
        }

        // GET: Clasificacion_Articulos
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClasificacionArticulos.ToListAsync());
        }

        // GET: Clasificacion_Articulos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacion_Articulos = await _context.ClasificacionArticulos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clasificacion_Articulos == null)
            {
                return NotFound();
            }

            return View(clasificacion_Articulos);
        }

        // GET: Clasificacion_Articulos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clasificacion_Articulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Clasificacion")] Clasificacion_Articulos clasificacion_Articulos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clasificacion_Articulos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clasificacion_Articulos);
        }

        // GET: Clasificacion_Articulos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacion_Articulos = await _context.ClasificacionArticulos.FindAsync(id);
            if (clasificacion_Articulos == null)
            {
                return NotFound();
            }
            return View(clasificacion_Articulos);
        }

        // POST: Clasificacion_Articulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Clasificacion")] Clasificacion_Articulos clasificacion_Articulos)
        {
            if (id != clasificacion_Articulos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clasificacion_Articulos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Clasificacion_ArticulosExists(clasificacion_Articulos.Id))
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
            return View(clasificacion_Articulos);
        }

        // GET: Clasificacion_Articulos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacion_Articulos = await _context.ClasificacionArticulos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clasificacion_Articulos == null)
            {
                return NotFound();
            }

            return View(clasificacion_Articulos);
        }

        // POST: Clasificacion_Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clasificacion_Articulos = await _context.ClasificacionArticulos.FindAsync(id);
            _context.ClasificacionArticulos.Remove(clasificacion_Articulos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Clasificacion_ArticulosExists(int id)
        {
            return _context.ClasificacionArticulos.Any(e => e.Id == id);
        }
    }
}
