using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Vendedor_Documento
    {
        public List<Vendedores> Vendedores { get; set; }
        public List<Tipos_de_Documentos> TiposDocumento { get; set; }
    }
}