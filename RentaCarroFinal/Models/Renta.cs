using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCarroFinal.Models
{
    
        public class Renta
        {
            public int? Id { get; set; }
            public int? EmpleadoId { get; set; }
            public Empleado Empleado { get; set; }
            public int? ClienteId { get; set; }
            public Cliente Cliente { get; set; }
            public DateTime FechaRenta { get; set; }
            public DateTime FechaDevolucion { get; set; }
            public double MontoDia { get; set; }
            public string Comentario { get; set; }
            public bool Estado { get; set; }

        }
    }

