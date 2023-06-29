using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Peluqueria.Models
{
    public enum TipoServicio
    {
        CORTE,
        COLOR,
        [Display(Name = "CORTE Y BARBA")]
        CORTE_Y_BARBA ,
        BARBA,
        LAVADO,
        [Display(Name = "CEJAS Y PERFILADO")]
        CEJAS_Y_PERFILADO,
        ALISADO,
        PERMANENTE,
        KERATINA,
        [Display(Name = "CORTE NIÑO")]
        CORTE_NIÑO
    }
}
