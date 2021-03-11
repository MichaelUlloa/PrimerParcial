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
    public class Formas_de_EnvioController : Controller
    {
        private readonly ParcialDbContext _context;

        public Formas_de_EnvioController(ParcialDbContext context)
        {
            _context = context;
        }

        // GET: Formas_de_Envio
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormasEnvio.ToListAsync());
        }

        // GET: Formas_de_Envio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formas_de_Envio = await _context.FormasEnvio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formas_de_Envio == null)
            {
                return NotFound();
            }

            return View(formas_de_Envio);
        }

        // GET: Formas_de_Envio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Formas_de_Envio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] Formas_de_Envio formas_de_Envio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formas_de_Envio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formas_de_Envio);
        }

        // GET: Formas_de_Envio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formas_de_Envio = await _context.FormasEnvio.FindAsync(id);
            if (formas_de_Envio == null)
            {
                return NotFound();
            }
            return View(formas_de_Envio);
        }

        // POST: Formas_de_Envio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] Formas_de_Envio formas_de_Envio)
        {
            if (id != formas_de_Envio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formas_de_Envio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Formas_de_EnvioExists(formas_de_Envio.Id))
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
            return View(formas_de_Envio);
        }

        // GET: Formas_de_Envio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formas_de_Envio = await _context.FormasEnvio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formas_de_Envio == null)
            {
                return NotFound();
            }

            return View(formas_de_Envio);
        }

        // POST: Formas_de_Envio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formas_de_Envio = await _context.FormasEnvio.FindAsync(id);
            _context.FormasEnvio.Remove(formas_de_Envio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Formas_de_EnvioExists(int id)
        {
            return _context.FormasEnvio.Any(e => e.Id == id);
        }
    }
}
