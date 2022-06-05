using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCarroFinal.Models
{
    public class Modelo
    {
        public int? Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public bool Estado { get; set; }
        [Required]
        public int? MarcaId { get; set; }
        public Marca? Marca { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
