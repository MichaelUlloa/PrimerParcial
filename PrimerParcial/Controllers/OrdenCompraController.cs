using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrimerParcial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Controllers
{
    public class OrdenCompraController : Controller
    {
        private readonly ParcialDbContext _context;
        public OrdenCompraController(ParcialDbContext context)
        {
            _context = context;
        }
        // GET: OrdenCompraController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrdenCompraController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdenCompraController/Create
        public ActionResult Create()
        {
            ViewData["Suplidores"] = new SelectList(_context.Suplidores, "Id", "Name");
            ViewData["FormasEnvio"] = new SelectList(_context.FormasEnvio, "Id", "Descripcion");
            ViewData["FormasPago"] = new SelectList(_context.FormasPago, "Id", "Descripcion");
            return View();
        }

        // POST: OrdenCompraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
