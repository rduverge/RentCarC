using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarroFinal.Models;

namespace RentaCarroFinal.Data
{
    internal class RentaRepo : IRecordRepo<Renta>
    {
        public Renta Create(Renta t)
        {
            t.Id = null;
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            var data = db.Add(t);
            db.SaveChanges();
            return data.Entity;
        }

        public void Delete(Renta t)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            db.Remove(t);
            db.SaveChanges();
        }
        public Renta Update(Renta t)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            var data = db.Update(t);
            db.SaveChanges();
            return data.Entity;
        }

        public List<Renta> View()
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            return db.Rentas.ToList();
        }
    }
}