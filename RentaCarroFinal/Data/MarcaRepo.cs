using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RentaCarroFinal.Data;
using RentaCarroFinal.Models;
using System.Threading.Tasks;

namespace RentaCarroFinal.Data
{
    internal class MarcaRepo : IRecordRepo<Marca>
    {
        public Marca Create(Marca t)
        {
            t.Id = null;
            using RentaCarroFinalContext empContext = new RentaCarroFinalContext();
            var data = empContext.Add(t);
            empContext.SaveChanges();
            return data.Entity;
        }

        public void Delete(Marca t)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            db.Remove(t);
            db.SaveChanges();
        }
        public Marca Update(Marca t)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            var data = db.Update(t);
            db.SaveChanges();
            return data.Entity;
        }

        public List<Marca> View(bool all = true)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            if (all)
            {
                return db.Marcas.ToList();

            }
            else
            {
                return db.Marcas.Where(x => x.Estado == true).ToList();

            }
        }
    }
}
