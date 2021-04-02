using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class OrdenCompraDetalle
    {
        public int Id { get; set; }
        public int OrdenCompraMasterId { get; set; }
        public OrdenCompraMaster OrdenCompraMaster { get; set; }
        public int ArticuloId { get; set; }
        public Articulos Articulo { get; set; }
        public string Descripcion { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }
        public int Cantidad { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ITBIS { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        public static implicit operator List<object>(OrdenCompraDetalle v)
        {
            throw new NotImplementedException();
        }
    }
}
