using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarroFinal.Models;

namespace RentaCarroFinal.Data
{
    internal class TipoVehiculoRepo : IRecordRepo<TipoVehiculo>
    {
        public TipoVehiculo Create(TipoVehiculo t)
        {
            t.Id = null;
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            var data = db.Add(t);
            db.SaveChanges();
            return data.Entity;
        }

        public void Delete(TipoVehiculo t)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            db.Remove(t);
            db.SaveChanges();
        }
        public TipoVehiculo Update(TipoVehiculo t)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            var data = db.Update(t);
            db.SaveChanges();
            return data.Entity;
        }

        public List<TipoVehiculo> View()
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            return db.TiposVehiculo.ToList();
        }
    }
}
