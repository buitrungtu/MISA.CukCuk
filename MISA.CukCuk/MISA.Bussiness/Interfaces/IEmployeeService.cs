using MISA.CukCuk.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NVMANH (15/10/2020)
        IEnumerable<Employee> Get();
        Employee GetById(Guid employeeId);
        int Insert(Employee employee);
        int Update(Employee employee);
        int Delete(Guid id);

    }
}
