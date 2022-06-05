using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarroFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace RentaCarroFinal.Data
{
    internal class VehiculoRepo : IRecordRepo<Vehiculo>
    {
        public Vehiculo Create(Vehiculo t)
        {
            t.Id = null;
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            var data = db.Add(t);
            db.SaveChanges();
            return data.Entity;
        }

        public void Delete(Vehiculo t)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            db.Remove(t);
            db.SaveChanges();
        }
        public Vehiculo Update(Vehiculo t)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            var data = db.Update(t);
            db.SaveChanges();
            return data.Entity;
        }

        public List<Vehiculo> View()
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            return db.Vehiculos.Include(x => x.Modelo).Include(x => x.Marca).Include(x => x.TipoVehiculo).Include(x => x.TipoCombustible).ToList();
        }
    }
}