using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Peluqueria.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre {get; set;}
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string DNI { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Contrasenia { get; set; }

        [EnumDataType(typeof(Rol))]
        public Rol Rol {get; set; }

        public string NombreCompleto { get => Nombre + " " + Apellido; }
    }


}
