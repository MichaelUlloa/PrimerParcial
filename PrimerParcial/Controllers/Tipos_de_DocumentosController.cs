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
    public class Tipos_de_DocumentosController : Controller
    {
        private readonly ParcialDbContext _context;

        public Tipos_de_DocumentosController(ParcialDbContext context)
        {
            _context = context;
        }

        // GET: Tipos_de_Documentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipos_de_Documentos.ToListAsync());
        }

        // GET: Tipos_de_Documentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos_de_Documentos = await _context.Tipos_de_Documentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipos_de_Documentos == null)
            {
                return NotFound();
            }

            return View(tipos_de_Documentos);
        }

        // GET: Tipos_de_Documentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipos_de_Documentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoDocumento")] Tipos_de_Documentos tipos_de_Documentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipos_de_Documentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipos_de_Documentos);
        }

        // GET: Tipos_de_Documentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos_de_Documentos = await _context.Tipos_de_Documentos.FindAsync(id);
            if (tipos_de_Documentos == null)
            {
                return NotFound();
            }
            return View(tipos_de_Documentos);
        }

        // POST: Tipos_de_Documentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoDocumento")] Tipos_de_Documentos tipos_de_Documentos)
        {
            if (id != tipos_de_Documentos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipos_de_Documentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tipos_de_DocumentosExists(tipos_de_Documentos.Id))
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
            return View(tipos_de_Documentos);
        }

        // GET: Tipos_de_Documentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos_de_Documentos = await _context.Tipos_de_Documentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipos_de_Documentos == null)
            {
                return NotFound();
            }

            return View(tipos_de_Documentos);
        }

        // POST: Tipos_de_Documentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipos_de_Documentos = await _context.Tipos_de_Documentos.FindAsync(id);
            _context.Tipos_de_Documentos.Remove(tipos_de_Documentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tipos_de_DocumentosExists(int id)
        {
            return _context.Tipos_de_Documentos.Any(e => e.Id == id);
        }
    }
}
