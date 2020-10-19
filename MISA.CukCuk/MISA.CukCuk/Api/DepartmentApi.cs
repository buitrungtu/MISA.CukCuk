using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Bussiness.Interfaces;
using MISA.Common.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentApi : BaseApi<Department>
    {
        public IBaseService<Department> _departmentService;
        public DepartmentApi(IBaseService<Department> departmentService) : base(departmentService)
        {
            _departmentService = departmentService;
        }
    }
}
