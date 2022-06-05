using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentaCarroFinal.Models;

namespace RentaCarroFinal.Data
{
    internal class UsuarioRepo : IRecordRepo<Usuario>
    {
        public Usuario Create(Usuario t)
        {
            t.Id = null;
            using RentaCarroFinalContext empContext = new RentaCarroFinalContext();
            var data = empContext.Add(t);
            empContext.SaveChanges();
            return data.Entity;
        }

        public void Delete(Usuario t)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            db.Remove(t);
            db.SaveChanges();
        }
        public Usuario Update(Usuario t)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            var data = db.Update(t);
            db.SaveChanges();
            return data.Entity;
        }

        public List<Usuario> View(bool all = true)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            return db.Usuarios.ToList();
        }
    }
}