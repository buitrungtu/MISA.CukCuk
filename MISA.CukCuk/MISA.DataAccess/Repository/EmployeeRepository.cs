﻿using MISA.CukCuk.Model;
using MISA.DataAccess.Interface;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class EmployeeRepository:BaseRepository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(IDatabaseContext<Employee> databaseContext) : base(databaseContext)
        {
        }

        public bool CheckEmployeeByCode(string employeeCode)
        {
            return _databaseContext.GetByCode(employeeCode);
        }

        public string GetMaxEmployeeCode()
        {
            return _databaseContext.GetMaxEmployeeCode();
        }

        
    }
}
