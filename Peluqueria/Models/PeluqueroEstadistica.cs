using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peluqueria.Models
{
    public class PeluqueroEstadistica
    {
        public int CantidadTurnos;
        public string NombrePeluquero;

        public PeluqueroEstadistica(int CantidadTurnos, string NombrePeluquero)
        {
            this.CantidadTurnos = CantidadTurnos;
            this.NombrePeluquero = NombrePeluquero;
        }
    }
}
