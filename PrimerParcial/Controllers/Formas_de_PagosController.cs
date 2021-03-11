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
    public class Formas_de_PagosController : Controller
    {
        private readonly ParcialDbContext _context;

        public Formas_de_PagosController(ParcialDbContext context)
        {
            _context = context;
        }

        // GET: Formas_de_Pagos
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormasPago.ToListAsync());
        }

        // GET: Formas_de_Pagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formas_de_Pagos = await _context.FormasPago
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formas_de_Pagos == null)
            {
                return NotFound();
            }

            return View(formas_de_Pagos);
        }

        // GET: Formas_de_Pagos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Formas_de_Pagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] Formas_de_Pagos formas_de_Pagos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formas_de_Pagos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formas_de_Pagos);
        }

        // GET: Formas_de_Pagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formas_de_Pagos = await _context.FormasPago.FindAsync(id);
            if (formas_de_Pagos == null)
            {
                return NotFound();
            }
            return View(formas_de_Pagos);
        }

        // POST: Formas_de_Pagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] Formas_de_Pagos formas_de_Pagos)
        {
            if (id != formas_de_Pagos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formas_de_Pagos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Formas_de_PagosExists(formas_de_Pagos.Id))
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
            return View(formas_de_Pagos);
        }

        // GET: Formas_de_Pagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formas_de_Pagos = await _context.FormasPago
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formas_de_Pagos == null)
            {
                return NotFound();
            }

            return View(formas_de_Pagos);
        }

        // POST: Formas_de_Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formas_de_Pagos = await _context.FormasPago.FindAsync(id);
            _context.FormasPago.Remove(formas_de_Pagos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Formas_de_PagosExists(int id)
        {
            return _context.FormasPago.Any(e => e.Id == id);
        }
    }
}
