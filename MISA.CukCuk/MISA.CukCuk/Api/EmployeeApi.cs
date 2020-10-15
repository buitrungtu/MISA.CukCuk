using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Bussiness.Interfaces;
using MISA.CukCuk.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApi : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeeApi(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult Get()
        {
            var employees = _employeeService.Get();
            if (employees.Count() > 0)
                return Ok(employees);
            else
                return NoContent();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{EmployeeCode}")]
        public object Get(string EmployeeCode)
        {
            // lấy thông tin 1 Employee thông qua ustomerCode
            return null;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        //POST để thêm
        public bool Post([FromBody] Employee Employee)
        {

            return false;
        }

        // PUT api/<EmployeeController>/5
        //[HttpPut("{EmployeeCode}")]
        // PUT để sửa
        public bool Put([FromBody] Employee Employee)
        {

            return false;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{strEmployeeCode}")]
        public bool Delete(string strEmployeeCode)
        {

            return true;
        }
    }
}
