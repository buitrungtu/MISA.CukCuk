using Microsoft.Extensions.DependencyInjection;
using MISA.Bussiness.Interfaces;
using MISA.Bussiness.Service;
using MISA.DataAccess.DatabaseAccess;
using MISA.DataAccess.Interface;
using MISA.DataAccess.Interfaces;
using MISA.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk
{
    public class DIConfig
    {
        public static void InjectionConfig(IServiceCollection services)
        {
            //config cho service
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            //config cho Repository
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            //config cho Database
            services.AddScoped(typeof(IBaseRepository<>), typeof(DatabaseContext<>));
        }
    }
}
