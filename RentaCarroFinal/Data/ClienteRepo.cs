using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarroFinal.Models;

namespace RentaCarroFinal.Data
{
    public class ClienteRepo : IRecordRepo<Cliente>
    {
        public Cliente Create(Cliente t)
        {
            t.Id = null;
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            var data = db.Add(t);
            db.SaveChanges();
            return data.Entity;
        }

        public void Delete(Cliente t)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            db.Remove(t);
            db.SaveChanges();
        }
        public Cliente Update(Cliente t)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            var data = db.Update(t);
            db.SaveChanges();
            return data.Entity;
        }

        public List<Cliente> View(bool all = true)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            if (all)
            {
                return db.Clientes.ToList();
            }
            else
            {
                return db.Clientes.Where(x => x.Estado == true).ToList();
            }
        }
    }
}
