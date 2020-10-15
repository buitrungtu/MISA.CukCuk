using MISA.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class BaseRepository<T>
    {
        IDatabaseContext<T> _databaseContext;
        public BaseRepository(IDatabaseContext<T> databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public bool CheckEmployeeByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get()
        {
            return _databaseContext.Get();
        }

        public T GetById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public int Insert(T employee)
        {
            throw new NotImplementedException();
        }

        public int Update(T employee)
        {
            throw new NotImplementedException();
        }
    }
}
