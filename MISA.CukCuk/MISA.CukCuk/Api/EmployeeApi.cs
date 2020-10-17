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
    public class EmployeeApi : BaseApi<Employee>
    {
        IBaseService<Employee> _employeeService;
        public EmployeeApi(IBaseService<Employee> employeeService):base(employeeService)
        {
            _employeeService = employeeService;
        }        
    }
}
