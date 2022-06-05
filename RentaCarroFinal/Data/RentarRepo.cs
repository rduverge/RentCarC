using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarroFinal.Models;
using Microsoft.EntityFrameworkCore;

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

        public List<Renta> View(bool all = true)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            if (all)
            {
                return db.Rentas.Include(x => x.Empleado).Include(x => x.Vehiculo).Include(x => x.Cliente).ToList();

            }
            else
            {
                return db.Rentas.Include(x => x.Empleado).Include(x => x.Vehiculo).Include(x => x.Cliente).Where(x => x.Estado == true).ToList();

            }
        }
    }
}