using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Bussiness.Interfaces;
using MISA.Common.Model;
using MISA.CukCuk.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApi : BaseApi<Employee>
    {
        IEmployeeService _employeeService;
        public EmployeeApi(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Lấy dữ liệu binding lên dialog
        /// </summary>
        /// Author: BTTu(19/10/2020)
        /// <returns></returns>
        [HttpGet("{GetDataDialog}")]
        public IActionResult GetDataDialog()
        {
            string rs = _employeeService.GetMaxEmployeeCode();
            try
            {
                int maxCode = Int32.Parse(rs.Replace("NV", ""));
                return Ok(maxCode);
            }
            catch (Exception)
            {

                return NoContent();
            }
        }
    }
}
