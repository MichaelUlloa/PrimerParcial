﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Marcas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Articulos> Articulos { get; set; }
    }
}
