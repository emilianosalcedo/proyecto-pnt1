using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peluqueria.Models
{
    public class ServicioEstadistica
    {
        public int CantidadTurnos;
        public string Servicio;

        public ServicioEstadistica(int CantidadTurnos, string desc)
        {
            this.CantidadTurnos = CantidadTurnos;
            this.Servicio = desc;
        }
    }
}
