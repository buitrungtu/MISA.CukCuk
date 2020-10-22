using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        /// Lấy mã nhân viên lớn nhất trong DB
        /// </summary>
        /// Author: BTTu (17/10/2020)
        /// <returns></returns>
        [HttpGet("{GetCode}/{maxCode}")]
        public IActionResult GetMaxEmployeeCode()
        {
            try
            {
                string rs = _employeeService.GetMaxEmployeeCode();
                int maxCode = Int32.Parse(rs.Replace("NV", "")) + 1;
                return Ok("NV" + maxCode);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        //[HttpPost("{fileUpLoad}")]
        //public IActionResult PostImage([FromBody] IFormFile file)
        //{
        //    try
        //    {
        //        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/upload", file.FileName);
        //        using (Stream stream = new FileStream(path, FileMode.Create))
        //        {
        //            file.CopyTo(stream);
        //        }
        //        return StatusCode(StatusCodes.Status201Created);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //}

    }
}
