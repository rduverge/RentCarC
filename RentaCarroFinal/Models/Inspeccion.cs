using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCarroFinal.Models
{
    public class Inspeccion
    {
        public int? Id { get; set; }
        public int? VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public double Combustible { get; set; }
        public bool tieneRalladuras { get; set; }
        public bool TieneGomaRespuesta { get; set; }
        public bool TieneGato { get; set; }
        public bool TieneRoturaCristal { get; set; }
        public bool CheckGomaIzqD { get; set; }
        public bool CheckGomaIzqT { get; set; }
        public bool CheckGomaDerD { get; set; }
        public bool CheckGomaDerT { get; set; }
        public DateTime Fecha { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        public bool Estado { get; set; }
    }
}
