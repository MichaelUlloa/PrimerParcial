using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrimerParcial.Models;

namespace PrimerParcial.ViewModels
{
    public class OrdenCompraViewModel
    {
        public OrdenCompraMaster OrdenCompraMasters { get; set; }
        public List<OrdenCompraDetalle> OrdenCompraDetalles { get; set; }
    }
}
