using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Peluqueria.Models
{
    public class Servicio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [EnumDataType(typeof(TipoServicio))]
        public TipoServicio Tipo { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set; }
        public int Duracion { get; set; }
    }
}
