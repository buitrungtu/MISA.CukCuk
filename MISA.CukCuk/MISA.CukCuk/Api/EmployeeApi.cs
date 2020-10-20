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
        /// Lấy dữ liệu có phân trang
        /// </summary>
        /// <param name="page">Trang</param>
        /// <param name="record">Bản ghi</param>
        /// Author: BTTu (18/10/2020)
        /// <returns></returns>
        [HttpGet("{paging}")]
        public IActionResult Get([FromQuery]int page, [FromQuery] int record)
        {
            var data = _employeeService.GetByPaging(record*(page - 1),record);
            if (data != null)
                return Ok(data);
            else
                return NoContent();
        }

        /// <summary>
        /// Lấy mã nhân viên lớn nhất trong DB
        /// </summary>
        /// Author: BTTu(19/10/2020)
        /// <returns></returns>
        [HttpGet("{employee}/{maxCode}")]
        public IActionResult GetMaxEmployeeCode()
        {
            try
            {
                string rs = _employeeService.GetMaxEmployeeCode();
                int maxCode = Int32.Parse(rs.Replace("NV", "")) + 1;
                return Ok("NV"+maxCode);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }
    }
}
