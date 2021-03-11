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
    public class Clasificacion_ClientesController : Controller
    {
        private readonly ParcialDbContext _context;

        public Clasificacion_ClientesController(ParcialDbContext context)
        {
            _context = context;
        }

        // GET: Clasificacion_Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClasificacionClientes.ToListAsync());
        }

        // GET: Clasificacion_Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacion_Clientes = await _context.ClasificacionClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clasificacion_Clientes == null)
            {
                return NotFound();
            }

            return View(clasificacion_Clientes);
        }

        // GET: Clasificacion_Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clasificacion_Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Clasificacion")] Clasificacion_Clientes clasificacion_Clientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clasificacion_Clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clasificacion_Clientes);
        }

        // GET: Clasificacion_Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacion_Clientes = await _context.ClasificacionClientes.FindAsync(id);
            if (clasificacion_Clientes == null)
            {
                return NotFound();
            }
            return View(clasificacion_Clientes);
        }

        // POST: Clasificacion_Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Clasificacion")] Clasificacion_Clientes clasificacion_Clientes)
        {
            if (id != clasificacion_Clientes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clasificacion_Clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Clasificacion_ClientesExists(clasificacion_Clientes.Id))
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
            return View(clasificacion_Clientes);
        }

        // GET: Clasificacion_Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacion_Clientes = await _context.ClasificacionClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clasificacion_Clientes == null)
            {
                return NotFound();
            }

            return View(clasificacion_Clientes);
        }

        // POST: Clasificacion_Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clasificacion_Clientes = await _context.ClasificacionClientes.FindAsync(id);
            _context.ClasificacionClientes.Remove(clasificacion_Clientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Clasificacion_ClientesExists(int id)
        {
            return _context.ClasificacionClientes.Any(e => e.Id == id);
        }
    }
}
