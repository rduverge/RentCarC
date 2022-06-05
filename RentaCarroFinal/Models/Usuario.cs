using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RentaCarroFinal.Models
{
    public class Usuario
    {
        public int? Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Password { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
