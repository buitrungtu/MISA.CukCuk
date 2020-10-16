using MISA.Bussiness.Interfaces;
using MISA.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class BaseService<T> : IBaseService<T>
    {
        IBaseRepository<T> _customerRepository;

        public BaseService(IBaseRepository<T> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get()
        {
            return _customerRepository.Get();
        }

        public T GetById(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public int Insert(T customer)
        {
            throw new NotImplementedException();
        }

        public int Update(T customer)
        {
            throw new NotImplementedException();
        }
    }
}
