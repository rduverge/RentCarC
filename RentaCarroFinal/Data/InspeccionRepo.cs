using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentaCarroFinal.Models;

namespace RentaCarroFinal.Data
{
    internal class InspeccionRepo : IRecordRepo<Inspeccion>
    {
        public Inspeccion Create(Inspeccion t)
        {
            t.Id = null;
            t.Empleado = null;
            t.Cliente = null;
            t.Vehiculo = null;
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            var data = db.Add(t);
            db.SaveChanges();
            return data.Entity;
        }

        public void Delete(Inspeccion t)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            db.Remove(t);
            db.SaveChanges();
        }
        public Inspeccion Update(Inspeccion t)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            var data = db.Update(t);
            db.SaveChanges();
            return data.Entity;
        }

        public List<Inspeccion> View(bool all = true)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            if (all)
            {
                return db.Inspecciones.Include(x => x.Vehiculo).Include(x => x.Cliente).Include(x => x.Empleado).ToList();

            }
            else
            {
                return db.Inspecciones.Include(x => x.Vehiculo).Include(x => x.Cliente).Include(x => x.Empleado).Where(x => x.Estado == true).ToList();
            }
        }
    }
}