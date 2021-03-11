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
    public class Unidades_de_MedidaController : Controller
    {
        private readonly ParcialDbContext _context;

        public Unidades_de_MedidaController(ParcialDbContext context)
        {
            _context = context;
        }

        // GET: Unidades_de_Medida
        public async Task<IActionResult> Index()
        {
            return View(await _context.Unidades_de_Medida.ToListAsync());
        }

        // GET: Unidades_de_Medida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidades_de_Medida = await _context.Unidades_de_Medida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidades_de_Medida == null)
            {
                return NotFound();
            }

            return View(unidades_de_Medida);
        }

        // GET: Unidades_de_Medida/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unidades_de_Medida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Medida,CantidadMedida")] Unidades_de_Medida unidades_de_Medida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidades_de_Medida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidades_de_Medida);
        }

        // GET: Unidades_de_Medida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidades_de_Medida = await _context.Unidades_de_Medida.FindAsync(id);
            if (unidades_de_Medida == null)
            {
                return NotFound();
            }
            return View(unidades_de_Medida);
        }

        // POST: Unidades_de_Medida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Medida,CantidadMedida")] Unidades_de_Medida unidades_de_Medida)
        {
            if (id != unidades_de_Medida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidades_de_Medida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Unidades_de_MedidaExists(unidades_de_Medida.Id))
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
            return View(unidades_de_Medida);
        }

        // GET: Unidades_de_Medida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidades_de_Medida = await _context.Unidades_de_Medida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidades_de_Medida == null)
            {
                return NotFound();
            }

            return View(unidades_de_Medida);
        }

        // POST: Unidades_de_Medida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidades_de_Medida = await _context.Unidades_de_Medida.FindAsync(id);
            _context.Unidades_de_Medida.Remove(unidades_de_Medida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Unidades_de_MedidaExists(int id)
        {
            return _context.Unidades_de_Medida.Any(e => e.Id == id);
        }
    }
}
