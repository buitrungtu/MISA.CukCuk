using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerApi : ControllerBase
    {
        CustomerAccess customerAccess = new CustomerAccess();
        // GET: api/<CustomerController>

        /// <summary>
        /// Lấy dữ liệu của Customer (30 bản ghi đầu tiên)
        /// Author: Bui Trung Tu (12/10/2020)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Customer> Get() //IEnumerable là interface (dạng kiểu mảng) có thể trả về list hoặc mảng 
        {
            // Lấy danh sách customer
            return customerAccess.GetData(30, 0);
        }
        /// <summary>
        /// Lấy dữ liệu có phân trang
        /// Author: Bui Trung Tu (12/10/2020)
        /// </summary>
        /// <param name="record">Số bản ghi</param>
        /// <param name="page">Trang muốn lấy (Số bản ghi bỏ qua) </param>
        /// <returns></returns>
        [HttpGet("{record}/{page}")]
        public IEnumerable<Customer> GetData(int record, int page)
        {
            return customerAccess.GetData(record, record * page);
        }

        /// <summary>
        /// Lấy dữ liệu của 1 customer
        /// Author: Bui Trung Tu (12/10/2020)
        /// </summary>
        /// <param name="customerID">ID khách hàng trong DB</param>
        /// <returns></returns>
        //GET api/<CustomerController>/5
        [HttpGet("{customerID}")]
        public object Get(string customerID)
        {
            return customerAccess.GetCustomerByID(customerID);
        }

        /// <summary>
        /// Thêm một Customer
        /// Author: Bui Trung Tu (12/10/2020)
        /// </summary>
        /// <param name="customer">Thông tin Customer thêm</param>
        /// <returns></returns>
        // POST api/<CustomerController>
        [HttpPost]
        public bool Post([FromBody] Customer customer)
        {
            if (customer != null)
            {
                // kiểm tra thêm thông tin nếu cần
                return customerAccess.InsertCustomer(customer);
            }
            return false;
        }

        /// <summary>
        /// Sửa thông tin Customer
        /// Author: Bui Trung Tu (12/10/2020)
        /// </summary>
        /// <param name="customer">Thông tin Customer sửa</param>
        /// <returns></returns>
        // PUT api/<CustomerController>/5
        public bool Put([FromBody] Customer customer)
        {
            return customerAccess.UpdateCustomer(customer);
        }

        /// <summary>
        /// Xóa Customer
        /// Author: Bui Trung Tu (12/10/2020)
        /// </summary>
        /// <param name="strCustomerID">Chuỗi các ID customer cần xóa</param>
        /// <returns></returns>
        // DELETE api/<CustomerController>/5
        [HttpDelete("{strCustomerID}")]
        public bool Delete(string strCustomerID)
        {
            string[] arr = strCustomerID.Split(",");
            bool check = true;
            foreach (var customerCode in arr)
            {
                if (customerAccess.DeleteCustomer(customerCode) == false)
                {
                    check = false;
                }
            }
            return check;
        }
    }
}
