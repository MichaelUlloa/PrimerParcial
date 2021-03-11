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
    public class Puestos_de_TrabajosController : Controller
    {
        private readonly ParcialDbContext _context;

        public Puestos_de_TrabajosController(ParcialDbContext context)
        {
            _context = context;
        }

        // GET: Puestos_de_Trabajos
        public async Task<IActionResult> Index()
        {
            return View(await _context.PuestosTrabajo.ToListAsync());
        }

        // GET: Puestos_de_Trabajos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestos_de_Trabajos = await _context.PuestosTrabajo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestos_de_Trabajos == null)
            {
                return NotFound();
            }

            return View(puestos_de_Trabajos);
        }

        // GET: Puestos_de_Trabajos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Puestos_de_Trabajos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Puestos_de_Trabajos puestos_de_Trabajos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puestos_de_Trabajos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(puestos_de_Trabajos);
        }

        // GET: Puestos_de_Trabajos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestos_de_Trabajos = await _context.PuestosTrabajo.FindAsync(id);
            if (puestos_de_Trabajos == null)
            {
                return NotFound();
            }
            return View(puestos_de_Trabajos);
        }

        // POST: Puestos_de_Trabajos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Puestos_de_Trabajos puestos_de_Trabajos)
        {
            if (id != puestos_de_Trabajos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puestos_de_Trabajos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Puestos_de_TrabajosExists(puestos_de_Trabajos.Id))
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
            return View(puestos_de_Trabajos);
        }

        // GET: Puestos_de_Trabajos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestos_de_Trabajos = await _context.PuestosTrabajo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestos_de_Trabajos == null)
            {
                return NotFound();
            }

            return View(puestos_de_Trabajos);
        }

        // POST: Puestos_de_Trabajos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var puestos_de_Trabajos = await _context.PuestosTrabajo.FindAsync(id);
            _context.PuestosTrabajo.Remove(puestos_de_Trabajos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Puestos_de_TrabajosExists(int id)
        {
            return _context.PuestosTrabajo.Any(e => e.Id == id);
        }
    }
}
