using MISA.Bussiness.Interfaces;
using MISA.CukCuk.Model;
using MISA.DataAccess.Interface;
using MISA.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.Get();
        }

        public Employee GetById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public int Insert(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
