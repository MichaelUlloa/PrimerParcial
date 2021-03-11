using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models
{
    public class Empleados
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [DisplayName("Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Hired Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime HiredDate { get; set; }

        //Relations with Puestos_de_Trabajos Model
        [DisplayName("Job Title")]
        [Required]
        public int JobTitleId { get; set; }
        public Puestos_de_Trabajos JobTitle { get; set; }

        //Relations with Empresas Model
        [Required]
        public int EmpresaId { get; set; }
        public Empresas Empresa { get; set; }
    }
}
