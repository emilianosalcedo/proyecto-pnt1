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
        public double? PrecioTotal;

        public ServicioEstadistica(int CantidadTurnos, string desc)
        {
            this.CantidadTurnos = CantidadTurnos;
            this.Servicio = desc;
        }
        public ServicioEstadistica(int CantidadTurnos, string desc, double precioTotal)
        {
            this.CantidadTurnos = CantidadTurnos;
            this.Servicio = desc;
            this.PrecioTotal = precioTotal;
        }
    }
}
