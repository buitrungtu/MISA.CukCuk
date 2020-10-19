using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Interfaces
{
    public interface IDatabaseContext<T>
    {
        IEnumerable<T> Get();
        T GetByID(object objId);
        int Insert(T obj);
        int Update(T obj);
        int Delete(Guid objID);
        bool GetByCode(string objCode);

        string GetMaxEmployeeCode();
    }
}
