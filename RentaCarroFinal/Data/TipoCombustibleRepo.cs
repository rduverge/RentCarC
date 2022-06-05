using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarroFinal.Data;
using RentaCarroFinal.Models;

namespace RentaCarroFinal.Data
{
    internal class TipoCombustibleRepo : IRecordRepo<TipoCombustible>
    {
        public TipoCombustible Create(TipoCombustible t)
        {
            t.Id = null;
            using RentaCarroFinalContext empContext = new RentaCarroFinalContext();
            var data = empContext.Add(t);
            empContext.SaveChanges();
            return data.Entity;
        }

        public void Delete(TipoCombustible t)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            db.Remove(t);
            db.SaveChanges();
        }
        public TipoCombustible Update(TipoCombustible t)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            var data = db.Update(t);
            db.SaveChanges();
            return data.Entity;
        }

        public List<TipoCombustible> View(bool all = true)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            if (all)
            {
                return db.TiposCombustible.ToList();

            }
            else
            {
                return db.TiposCombustible.Where(x => x.Estado == true).ToList();

            }
        }
    }
}