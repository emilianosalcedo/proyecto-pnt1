using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Peluqueria.Models
{
    public class Turno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public bool Atendido { get; set; }
        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; }

        public int ClienteId { get; set; }
        public Usuario Cliente { get; set; }

        //public int PeluqueroId { get; set; }
        //public Usuario Peluquero { get; set; }
    }
}
