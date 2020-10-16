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
    public class CustomerApi : ControllerBase
    {
        IBaseService<Customer> _customerService;
        public CustomerApi(IBaseService<Customer> customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Lấy dữ liệu của Customer (30 bản ghi đầu tiên)
        /// </summary>
        /// Author: Bui Trung Tu (15/10/2020)
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var customers = _customerService.Get();
            if (customers.Count() > 0)
                return Ok(customers);
            else
                return NoContent();
        }
        /// <summary>
        /// Lấy dữ liệu có phân trang
        /// Author: Bui Trung Tu (12/10/2020)
        /// </summary>
        /// <param name="record">Số bản ghi</param>
        /// <param name="page">Trang muốn lấy (Số bản ghi bỏ qua) </param>
        /// <returns></returns>
        [HttpGet("{record}/{page}")]
        public IActionResult GetData(int record, int page)
        {
            var customers = _customerService.Get();
            if (customers.Count() > 0)
                return Ok(customers);
            else
                return NoContent();
        }

    }
}
