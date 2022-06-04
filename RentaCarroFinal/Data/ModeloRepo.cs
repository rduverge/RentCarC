using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RentaCarroFinal.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentaCarroFinal.Data;

namespace RentaCarroFinal.Data
{
    internal class ModeloRepo : IRecordRepo<Modelo>
    {
        public Modelo Create(Modelo t)
        {
            t.Id = null;
            t.Marca = null;
            using RentaCarroFinalContext empContext = new RentaCarroFinalContext();
            var data = empContext.Add(t);
            empContext.SaveChanges();
            return data.Entity;
        }

        public void Delete(Modelo t)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            db.Remove(t);
            db.SaveChanges();
        }
        public Modelo Update(Modelo t)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            var data = db.Update(t);
            db.SaveChanges();
            return data.Entity;
        }

        public List<Modelo> View()
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            return db.Modelos.Include(m => m.Marca).ToList();
        }
    }
}
