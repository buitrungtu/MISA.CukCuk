using MISA.CukCuk.Model;
using MISA.DataAccess.Interface;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class EmployeeRepository:BaseRepository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(IBaseRepository<Employee> employeeRepository) : base(employeeRepository)
        {
        }

        public bool CheckEmployeeByCode(string employeeCode)
        {
            var obj = _baseRepository.GetByID(employeeCode);
            if (obj == null) return false;
            else
                return true;
        }
    }
}
