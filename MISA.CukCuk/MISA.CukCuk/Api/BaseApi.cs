using Microsoft.AspNetCore.Mvc;
using MISA.Bussiness.Interfaces;
using MISA.CukCuk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApi<T> : ControllerBase
    {
        IBaseService<T> _baseService;
        public BaseApi(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// Author: BTTu (17/10/2020)
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var rs = _baseService.Get();
            if (rs != null)
                return Ok(rs);
            else
                return NoContent();
        }

        /// <summary>
        /// Lấy dữ liệu của 1 đối tượng
        /// </summary>
        /// <param name="objID">ID của đối tượng</param>
        /// Author: BTTu (17/10/2020)
        /// <returns></returns>
        [HttpGet("{objID}")]
        public IActionResult Get([FromRoute] Guid objID)
        {
            var obj = _baseService.GetById(objID);
            if (obj != null)
                return Ok(obj);
            else
                return NoContent();
        }

        /// <summary>
        /// Thêm 1 đối tượng
        /// </summary>
        /// <param name="obj">đối tượng</param>
        /// Author: BTTu (17/10/2020)
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] T obj)
        {
            var serviceResponse = _baseService.Insert(obj);
            var affectRows = serviceResponse.Data != null ? ((int)serviceResponse.Data) : 0;
            if (affectRows > 0)
                return CreatedAtAction("POST", affectRows);
            else
                return BadRequest(serviceResponse);
        }

        /// <summary>
        /// Sửa thông tin 
        /// </summary>
        /// <param name="obj">đối tượng</param>
        /// Author: BTTu (17/10/2020)
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] T obj)
        {
            var serviceResponse = _baseService.Update(obj);
            var affectRows = serviceResponse.Data != null ? ((int)serviceResponse.Data) : 0;
            if (affectRows > 0)
                return CreatedAtAction("PUT", affectRows);
            else
                return BadRequest(serviceResponse);
        }

        /// <summary>
        /// Xóa 1 đối tượng
        /// </summary>
        /// <param name="objID">ID của đối tượng</param>
        /// Author: BTTu (17/10/2020)
        /// <returns></returns>
        [HttpDelete("{objID}")]
        public IActionResult Delete([FromRoute] Guid objID)
        {
            var serviceResponse = _baseService.Delete(objID);
            var affectRows = serviceResponse.Data != null ? ((int)serviceResponse.Data) : 0;
            if (affectRows > 0)
                return CreatedAtAction("DELETE", affectRows);
            else
                return BadRequest(serviceResponse);
        }
    }
}
