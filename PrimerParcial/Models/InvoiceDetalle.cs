using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class InvoiceDetalle
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public InvoiceMaster Master { get; set; }
        public int ArticuloId { get; set; }
        public Articulos Articulo { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Value must be a positive number.")]
        public int Cantidad { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ITBIS { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
    }
}
