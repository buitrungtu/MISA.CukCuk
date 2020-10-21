using MISA.CukCuk.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Interfaces
{
    public interface IEmployeeService:IBaseService<Employee>
    {
        /// <summary>
        /// Kiểm tra mã nhân viên có tồn tại trong DB hay không
        /// </summary>
        /// <param name="employeeCode">mã nhân viên</param>
        /// Author: BTTu (21/10/2020)
        /// <returns></returns>
        bool CheckEmployeeByCode(string employeeCode);

        /// <summary>
        /// Lấy ra mã nhân viên lớn nhất 
        /// </summary>
        /// Author: BTTu (21/10/2020)
        /// <returns></returns>
        string GetMaxEmployeeCode();

    }
}
