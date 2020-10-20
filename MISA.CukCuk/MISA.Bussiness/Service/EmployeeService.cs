using MISA.Bussiness.Interfaces;
using MISA.CukCuk.Model;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class EmployeeService : BaseService<Employee>,IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public bool CheckEmployeeByCode(string employeeCode)
        {
            return _employeeRepository.CheckEmployeeByCode(employeeCode);
        }

        public string GetMaxEmployeeCode()
        {
            return _employeeRepository.GetMaxEmployeeCode();
        }

        protected override bool Validate(Employee entity,string Method)
        {
            var isValid = true;
            if(entity.EmployeeCode.Trim() == "" || entity.EmployeeName.Trim() == "" || entity.Email.Trim() == "" || entity.Mobile.Trim() == "")
            {
                isValid = false;
                validateErrorResponseMsg.Add("Bạn phải nhập thông tin các trường bắt buộc");
            }
            else
            {
                // check email 
                try
                {
                    MailAddress mail = new MailAddress(entity.Email);
                }
                catch(FormatException)
                {
                    isValid = false;
                    validateErrorResponseMsg.Add("Email không đúng định dạng");
                }
                if(Method == "POST")
                {
                    //check trùng mã:
                    var isValidCode = CheckEmployeeByCode(entity.EmployeeCode);
                    if (isValidCode) // nếu đã có 1 nhân viên có mã như vậy
                    {
                        isValid = false;
                        validateErrorResponseMsg.Add("Mã nhân viên này đã tồn tại");
                    }
                }
            }
            return isValid;
        }
    }
}
