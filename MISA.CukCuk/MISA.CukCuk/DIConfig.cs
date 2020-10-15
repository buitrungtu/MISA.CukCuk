using Microsoft.Extensions.DependencyInjection;
using MISA.Bussiness.Interfaces;
using MISA.Bussiness.Service;
using MISA.DataAccess.DatabaseAccess;
using MISA.DataAccess.Interface;
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
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped(typeof(IDatabaseContext<>), typeof(DatabaseContext<>));
        }
    }
}
