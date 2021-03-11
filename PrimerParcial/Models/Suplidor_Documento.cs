using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Suplidor_Documento
    {
        public List<Suplidores> Suplidores { get; set; }
        public List<Tipos_de_Documentos> TiposDocumento { get; set; }
    }
}
