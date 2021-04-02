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

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        [DisplayName("Fecha de pedido")]
        public DateTime FechaPedido { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        [DisplayName("Fecha de salida")]
        public DateTime FechaSalida { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        [DisplayName("Fecha de llegada")]
        public DateTime FechaLlegada { get; set; }

        public int FormaEnvioId { get; set; }
        public Formas_de_Envio FormaEnvio { get; set; }

        public int FormaPagoId { get; set; }
        public Formas_de_Pagos FormaPago { get; set; }

        public List<OrdenCompraDetalle> OrdenCompraDetalles { get; set; }
    }
}
