using MISA.CukCuk.Model;
using MISA.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Interfaces
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {

        /// <summary>
        /// Kiểm tra trùng mã hay không
        /// </summary>
        /// <param name="employeeCode">mã nhân viên</param>
        /// Author: BTTu(18/10/2020)
        /// <returns></returns>
        bool CheckEmployeeByCode(string employeeCode);

        /// <summary>
        /// Lấy ra mã nhân viên lớn nhất trong hệ thống
        /// </summary>
        /// Author: BTTu(18/10/2020)
        /// <returns></returns>
        string GetMaxEmployeeCode();
    }
}
