using MISA.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class BaseRepository<T>:IBaseRepository<T>
    {
        IBaseRepository<T> _baseRepository;
        public BaseRepository(IBaseRepository<T> databaseContext)
        {
            _baseRepository = databaseContext;
        }

        public IEnumerable<T> Get()
        {
            return _baseRepository.Get();
        }

        public T GetById(Guid objID)
        {
            throw new NotImplementedException();
        }
        public int Insert(T obj)
        {
            throw new NotImplementedException();
        }

        public int Update(T obj)
        {
            throw new NotImplementedException();
        }
        public int Delete(Guid objID)
        {
            throw new NotImplementedException();
        }    
    }
}
