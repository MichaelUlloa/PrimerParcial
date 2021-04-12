using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models
{
    public class OrdenCompraMaster
    {
        public int Id { get; set; }

        public int SuplidorId { get; set; }
        public Suplidores Suplidor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DisplayName("Fecha de pedido")]
        public DateTime FechaPedido { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DisplayName("Fecha de salida")]
        public DateTime FechaSalida { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DisplayName("Fecha de llegada")]
        public DateTime FechaLlegada { get; set; }

        [Required]
        public int FormaEnvioId { get; set; }
        public Formas_de_Envio FormaEnvio { get; set; }

        [Required]
        public int FormaPagoId { get; set; }
        public Formas_de_Pagos FormaPago { get; set; }

        public List<OrdenCompraDetalle> OrdenCompraDetalles { get; set; }
    }
}
