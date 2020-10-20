using Microsoft.AspNetCore.Mvc;
using MISA.Bussiness.Interfaces;
using MISA.Common.Model;
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
        /// Lấy dữ liệu có phân trang
        /// </summary>
        /// <param name="page">Trang</param>
        /// <param name="record">Bản ghi</param>
        /// Author: BTTu (18/10/2020)
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromQuery] int page, [FromQuery] int record)
        {
            var pagingObject = new PagingObject();
            pagingObject.TotalRecord = 1000;
            pagingObject.TotalPage = Convert.ToInt32(Math.Ceiling((decimal)pagingObject.TotalRecord / (decimal)record));
            pagingObject.Data = _baseService.Get(record * (page - 1), record);
            if (pagingObject.Data != null)
                return Ok(pagingObject);
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
            //TODO: Sửa db phần lấy thông tin
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
            {
                serviceResponse.Msg.Add("Không tìm thấy nhân viên này");
                return BadRequest(serviceResponse);
            }   
        }
    }
}
