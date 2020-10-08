using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get() //IEnumerable là interface (dạng kiểu mảng) có thể trả về list hoặc mảng 
        {
            // Lấy danh sách Employee
            return Employee.EmployeeList;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{EmployeeCode}")]
        public object Get(string EmployeeCode)
        {
            // lấy thông tin 1 Employee thông qua ustomerCode
            return Employee.EmployeeList.Where(x => x.EmployeeCode == EmployeeCode).FirstOrDefault();
        }

        // POST api/<EmployeeController>
        [HttpPost]
        //POST để thêm
        public bool Post([FromBody] Employee Employee)
        {
            if (Employee != null)
            {
                // tạo id cho Employee mới
                Employee.EmployeeID = Guid.NewGuid();
                // thêm vào list
                Employee.EmployeeList.Add(Employee);
                return true;
            }
            return false;
        }

        // PUT api/<EmployeeController>/5
        //[HttpPut("{EmployeeCode}")]
        // PUT để sửa
        public bool Put([FromBody] Employee Employee)
        {
            var EmployeeEdit = Employee.EmployeeList.Where(x => x.EmployeeCode == Employee.EmployeeCode).FirstOrDefault();
            if (EmployeeEdit != null)
            {
                EmployeeEdit.EmployeeName = Employee.EmployeeName;
                EmployeeEdit.Gender = Employee.Gender;
                EmployeeEdit.DepartmentName = Employee.DepartmentName;
                EmployeeEdit.PositionName = Employee.PositionName;
                EmployeeEdit.WorkStatus = Employee.WorkStatus;
                EmployeeEdit.Mobile = Employee.Mobile;
                EmployeeEdit.Birthday = Employee.Birthday;
                EmployeeEdit.Salary = Employee.Salary;
                EmployeeEdit.Email = Employee.Email;
                EmployeeEdit.Address = Employee.Address;
                return true;
            }
            return false;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{strEmployeeCode}")]
        public bool Delete(string strEmployeeCode)
        {
            string[] arr = strEmployeeCode.Split(",");
            bool check = true;
            foreach (var EmployeeCode in arr)
            {
                var EmployeeDelete = Employee.EmployeeList.Where(x => x.EmployeeCode == EmployeeCode).FirstOrDefault();
                if (EmployeeDelete != null)
                {
                    Employee.EmployeeList.Remove(EmployeeDelete);
                }
                else
                {
                    check = false;
                }
            }
            return check;          
        }
    }
}
