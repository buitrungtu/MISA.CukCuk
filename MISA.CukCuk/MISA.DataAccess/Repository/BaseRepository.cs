using MISA.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class BaseRepository<T>:IBaseRepository<T>
    {
        protected IBaseRepository<T> _baseRepository;
        public BaseRepository(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public IEnumerable<T> Get()
        {
            return _baseRepository.Get();
        }

        public T GetByID(object objID)
        {
            return _baseRepository.GetByID(objID);
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
