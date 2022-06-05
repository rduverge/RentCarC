using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCarroFinal.Models
{
    enum TipoPersona
    {
        Fisica,
        Juridica
    }
    public class Cliente
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string NumeroTarjetaCredito { get; set; }
        public double LimiteCredito { get; set; }
        public string TipoPersona { get; set; }
        public bool Estado { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}