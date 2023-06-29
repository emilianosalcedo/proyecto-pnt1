using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peluqueria.Models
{
    public class TurnoEstadistica
    {
        public int Año;
        public int Mes;
        public int Cantidad;

        public TurnoEstadistica(int year, int month, int v)
        {
            Año = year;
            Mes = month;
            Cantidad = v;
        }
    }
}
