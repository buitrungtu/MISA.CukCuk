using MISA.DataAccess.Interface;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class BaseRepository<T>:IBaseRepository<T>
    {
        protected IDatabaseContext<T> _databaseContext;
        public BaseRepository(IDatabaseContext<T> databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<T> Get()
        {
            return _databaseContext.Get();
        }

        public T GetByID(object objID)
        {
            return _databaseContext.GetByID(objID);
        }
        public int Insert(T obj)
        {
            return _databaseContext.Insert(obj);
        }

        public int Update(T obj)
        {
            return _databaseContext.Update(obj);
        }
        public int Delete(Guid objID)
        {
            return _databaseContext.Delete(objID);
        }    
    }
}
