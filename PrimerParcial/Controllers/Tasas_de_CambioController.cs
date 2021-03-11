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
    public class Tasas_de_CambioController : Controller
    {
        private readonly ParcialDbContext _context;

        public Tasas_de_CambioController(ParcialDbContext context)
        {
            _context = context;
        }

        // GET: Tasas_de_Cambio
        public async Task<IActionResult> Index()
        {
            var parcialDbContext = _context.Tasas_de_Cambio.Include(t => t.Monedas);
            return View(await parcialDbContext.ToListAsync());
        }

        // GET: Tasas_de_Cambio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasas_de_Cambio = await _context.Tasas_de_Cambio
                .Include(t => t.Monedas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasas_de_Cambio == null)
            {
                return NotFound();
            }

            return View(tasas_de_Cambio);
        }

        // GET: Tasas_de_Cambio/Create
        public IActionResult Create()
        {
            ViewData["MonedasId"] = new SelectList(_context.Monedas, "Id", "Name");
            return View();
        }

        // POST: Tasas_de_Cambio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParDeMoneda,Equivalencia,MonedasId")] Tasas_de_Cambio tasas_de_Cambio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tasas_de_Cambio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MonedasId"] = new SelectList(_context.Monedas, "Id", "Name", tasas_de_Cambio.MonedasId);
            return View(tasas_de_Cambio);
        }

        // GET: Tasas_de_Cambio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasas_de_Cambio = await _context.Tasas_de_Cambio.FindAsync(id);
            if (tasas_de_Cambio == null)
            {
                return NotFound();
            }
            ViewData["MonedasId"] = new SelectList(_context.Monedas, "Id", "Name", tasas_de_Cambio.MonedasId);
            return View(tasas_de_Cambio);
        }

        // POST: Tasas_de_Cambio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ParDeMoneda,Equivalencia,MonedasId")] Tasas_de_Cambio tasas_de_Cambio)
        {
            if (id != tasas_de_Cambio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tasas_de_Cambio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tasas_de_CambioExists(tasas_de_Cambio.Id))
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
            ViewData["MonedasId"] = new SelectList(_context.Monedas, "Id", "Name", tasas_de_Cambio.MonedasId);
            return View(tasas_de_Cambio);
        }

        // GET: Tasas_de_Cambio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasas_de_Cambio = await _context.Tasas_de_Cambio
                .Include(t => t.Monedas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasas_de_Cambio == null)
            {
                return NotFound();
            }

            return View(tasas_de_Cambio);
        }

        // POST: Tasas_de_Cambio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tasas_de_Cambio = await _context.Tasas_de_Cambio.FindAsync(id);
            _context.Tasas_de_Cambio.Remove(tasas_de_Cambio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tasas_de_CambioExists(int id)
        {
            return _context.Tasas_de_Cambio.Any(e => e.Id == id);
        }
    }
}
