using MISA.CukCuk.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Interfaces
{
   public interface ICustomerService
    {

        IEnumerable<Customer> Get();
        Customer GetById(Guid customerId);
        int Insert(Customer customer);
        int Update(Customer customer);
        int Delete(Guid id);
    }
}
