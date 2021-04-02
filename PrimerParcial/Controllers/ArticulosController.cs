using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrimerParcial.Data;
using PrimerParcial.Models;
using PrimerParcial.ViewModels;

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
            var parcialDbContext = _context.Articulos.Include(a => a.ClasificacionArticulos).Include(a => a.Marca).Include(a => a.UnidadesDeMedida);

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
                .Include(a => a.ClasificacionArticulos)
                .Include(a => a.Marca)
                .Include(a => a.UnidadesDeMedida)
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
            ViewData["ClasificacionArticulosId"] = new SelectList(_context.ClasificacionArticulos, "Id", "Clasificacion");
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre");
            ViewData["UnidadesDeMedidaId"] = new SelectList(_context.Set<Unidades_de_Medida>(), "Id", "Medida");

            return View();
        }

        // POST: Articulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Stock,Description,ClasificacionArticulosId,MarcaId,UnidadesDeMedidaId")] Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articulos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClasificacionArticulosId"] = new SelectList(_context.ClasificacionArticulos, "Id", "Clasificacion", articulos.ClasificacionArticulosId);
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre", articulos.MarcaId);
            ViewData["UnidadesDeMedidaId"] = new SelectList(_context.Set<Unidades_de_Medida>(), "Id", "Medida", articulos.UnidadesDeMedidaId);
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
            ViewData["ClasificacionArticulosId"] = new SelectList(_context.ClasificacionArticulos, "Id", "Clasificacion", articulos.ClasificacionArticulosId);
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre", articulos.MarcaId);
            ViewData["UnidadesDeMedidaId"] = new SelectList(_context.Set<Unidades_de_Medida>(), "Id", "Medida", articulos.UnidadesDeMedidaId);
            return View(articulos);
        }

        // POST: Articulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Stock,Description,ClasificacionArticulosId,MarcaId,UnidadesDeMedidaId")] Articulos articulos)
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
            ViewData["ClasificacionArticulosId"] = new SelectList(_context.ClasificacionArticulos, "Id", "Clasificacion", articulos.ClasificacionArticulosId);
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre", articulos.MarcaId);
            ViewData["UnidadesDeMedidaId"] = new SelectList(_context.Set<Unidades_de_Medida>(), "Id", "Medida", articulos.UnidadesDeMedidaId);
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
                .Include(a => a.ClasificacionArticulos)
                .Include(a => a.Marca)
                .Include(a => a.UnidadesDeMedida)
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
