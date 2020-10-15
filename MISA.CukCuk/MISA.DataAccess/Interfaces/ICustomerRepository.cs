using MISA.CukCuk.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Interface
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: BTTu (15/10/2020)
        IEnumerable<Customer> Get();
        Customer GetById(Guid employeeId);
        int Insert(Customer employee);
        int Update(Customer employee);
        int Delete(Guid id);

        /// <summary>
        /// Kiểm tra thông tin nhân viên theo mã
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns>true: có; false: không</returns>
        /// CreatedBy: BTTu (14/10/2020)
    }
}
