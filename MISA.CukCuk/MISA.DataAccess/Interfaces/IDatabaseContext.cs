using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Interface
{
    public interface IDatabaseContext<T>
    {
        IEnumerable<T> Get();
        T GetById(Guid employeeId);
        int Insert(T employee);
        int Update(T employee);
        int Delete(Guid id);
    }
}
