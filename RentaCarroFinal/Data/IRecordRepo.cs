using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCarroFinal.Data
{
    internal interface IRecordRepo<T>
    {
        T Create(T record);

        T Update(T record);

        void Delete(T record);

        List<T> View();
    }
}
