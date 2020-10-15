using MISA.Bussiness.Interfaces;
using MISA.CukCuk.Model;
using MISA.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _customerRepository;
       
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Get()
        {
            return _customerRepository.Get();
        }

        public Customer GetById(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public int Insert(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
