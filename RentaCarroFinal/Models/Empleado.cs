using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCarroFinal.Models
{
    public class Empleado
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Tanda { get; set; }
        public int Comision { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}