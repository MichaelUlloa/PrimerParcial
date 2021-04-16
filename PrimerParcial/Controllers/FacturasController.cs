using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrimerParcial.Data;
using PrimerParcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Controllers
{
    public class FacturasController : Controller
    {
        private readonly ParcialDbContext _context;
        private static InvoiceMaster _master;
        private static List<InvoiceDetalle> invoiceDetalles;
        public FacturasController(ParcialDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var facturas = _context.InvoiceMaster
                .Include(a => a.Cliente);

            return View(facturas);
        }
        public IActionResult Create()
        {
            ViewData["Clientes"] = new SelectList(_context.Clientes, "Id", "Nombre");
            ViewData["Articulos"] = new SelectList(_context.Articulos, "Id", "Name");

            _master = new InvoiceMaster()
            {
                InvoiceDetalles = invoiceDetalles is null ? new List<InvoiceDetalle>() : invoiceDetalles
            };

            return View(_master);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId")] InvoiceMaster master)
        {
            master.InvoiceDetalles = invoiceDetalles;
            master.FechaFactura = DateTime.Now;

            _context.InvoiceMaster.Add(master);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));    
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDetalle([Bind("ArticuloId,Cantidad")] InvoiceDetalle detalle)
        {
            if (invoiceDetalles is null)
                invoiceDetalles = new List<InvoiceDetalle>();

            if (ModelState.IsValid)
            {
                var seq = _context.InvoiceMaster.OrderByDescending(x => x.Id).FirstOrDefault();
                int id = 0;

                if (seq is null)
                    id = 1;
                else
                    id = seq.Id + 1;

                var article = _context.Articulos.Find(detalle.ArticuloId);
                decimal price = article.Price;

                detalle.MasterId = id;
                detalle.Subtotal = price * detalle.Cantidad;
                detalle.ITBIS = detalle.Subtotal * (decimal)0.18;
                detalle.Total = detalle.Subtotal + detalle.ITBIS;

                invoiceDetalles.Add(detalle);
                return RedirectToAction(nameof(Create));
            }

            return View();
        }
        public IActionResult DeleteDetalle(int? id)
        {
            if (id is null)
                return NotFound();

            //0-based index
            invoiceDetalles.RemoveAt((int)id - 1);

            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> PrintPdf(int? id)
        {
            if (id is null)
                return NotFound();

            var master = await _context.InvoiceMaster
                .Include(a => a.Cliente)
                .Include(a => a.InvoiceDetalles)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (master is null)
                return NotFound();

            var invoicePrint = new InvoicePrint(master);

            return View(invoicePrint);
        }
    }
}