using MISA.CukCuk.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Interfaces
{
    public interface IEmployeeService:IBaseService<Employee>
    {
        bool CheckEmployeeByCode(string employeeCode);
        string GetMaxEmployeeCode();
    }
}
