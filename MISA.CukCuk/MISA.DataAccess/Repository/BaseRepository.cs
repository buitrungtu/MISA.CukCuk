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

        public T GetById(object objID)
        {
            return _baseRepository.GetById(objID);
        }
        public int Insert(T obj)
        {
            return _baseRepository.Insert(obj);
        }

        public int Update(T obj)
        {
            return _baseRepository.Update(obj);
        }
        public int Delete(Guid objID)
        {
            return _baseRepository.Delete(objID);
        }    
    }
}
