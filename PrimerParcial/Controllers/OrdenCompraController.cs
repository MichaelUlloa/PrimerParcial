using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrimerParcial.Data;
using PrimerParcial.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimerParcial.Controllers
{
    public class OrdenCompraController : Controller
    {
        private readonly ParcialDbContext _context;
        private static List<OrdenCompraDetalle> detalles;
        public OrdenCompraController(ParcialDbContext context)
        {
            _context = context;
        }
        // GET: OrdenCompraController
        public ActionResult Index()
        {
            var parcialDbContext = _context.OrdenCompraMasters.Include(a => a.Suplidor).Include(a => a.FormaEnvio).Include(a => a.FormaPago).Include(a => a.OrdenCompraDetalles);

            return View(parcialDbContext);
        }

        // GET: OrdenCompraController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        private void CreateViewData()
        {
            ViewData["Suplidores"] = new SelectList(_context.Suplidores, "Id", "Name");
            ViewData["FormasEnvio"] = new SelectList(_context.FormasEnvio, "Id", "Descripcion");
            ViewData["FormasPago"] = new SelectList(_context.FormasPago, "Id", "Descripcion");
            ViewData["Articulos"] = new SelectList(_context.Articulos, "Id", "Name");
        }
        // GET: OrdenCompraController/Create
        public ActionResult Create()
        {
            CreateViewData();
            var ordenCompra = new OrdenCompraMaster()
            {
                OrdenCompraDetalles = detalles is null ? new List<OrdenCompraDetalle>() : detalles
            };

            return View(ordenCompra);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuplidorId,FechaPedido,FechaSalida,FechaLlegada,FormaEnvioId,FormaPagoId")] OrdenCompraMaster master)
        {
            if (ModelState.IsValid)
            {
                master.OrdenCompraDetalles = detalles;
                master.FechaPedido = DateTime.Now;
                _context.OrdenCompraMasters.Add(master);
                await _context.SaveChangesAsync();
            }

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDetalle([Bind("ArticuloId,Descripcion,Subtotal,Cantidad")] OrdenCompraDetalle detalle)
        {
            if (detalles is null)
                detalles = new List<OrdenCompraDetalle>();

            if (ModelState.IsValid)
            {
                var article = _context.Articulos.Find(detalle.ArticuloId);
                decimal price = article.Price;

                detalle.Precio = price;
                detalle.Subtotal = price * detalle.Cantidad;
                detalle.ITBIS = detalle.Subtotal * (decimal) 0.18;
                detalle.Total = detalle.Subtotal + detalle.ITBIS;

                detalles.Add(detalle);
                return RedirectToAction(nameof(Create));
            }

            return View();    
        }

        // GET: OrdenCompraController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdenCompraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenCompraController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdenCompraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
