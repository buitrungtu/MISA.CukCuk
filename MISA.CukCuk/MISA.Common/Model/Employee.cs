using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Model
{
    public class Employee
    {
        #region "Constructor"
        
        #endregion
        #region "Property"
        /// <summary>
        /// Khóa chính (ID nhân viên)
        /// </summary>
        public Guid? EmployeeID { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public Gender Gender { get; set; }
        public string GenderName
        {
            get
            {
                switch(Gender)
                {
                    case Gender.Female:
                        return "Nữ";
                    case Gender.Male:
                        return "Nam";
                    case Gender.Gay:
                        return "Gay";
                    case Gender.Less:
                        return "Less";
                    default:
                        return "Không xác định";
                }
            }            
        }
        /// <summary>
        /// Điện thoại di động
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Vị trí
        /// </summary>
        public int PositionID { get; set; }
        public string PositionName { get; set; }

        /// <summary>
        /// Phòng ban
        /// </summary>
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Số tiền lương
        /// </summary>
        public double Salary { get; set; }


        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Tình trạng công việc
        /// </summary>
        public WorkStatus WorkStatus { get; set; }
        public string WorkStatusName
        {
            get
            {
                switch(WorkStatus){
                    case WorkStatus.Working:
                        return "Đang làm việc";
                    case WorkStatus.Stopped:
                        return "Đã nghỉ việc";
                    case WorkStatus.Waiting:
                        return "Đang thử việc";
                    case WorkStatus.Childbirth:
                        return "Đang nghỉ sinh sản";
                    case WorkStatus.Foreign:
                        return "Đang công tác nước ngoài";
                    default:
                        return "Không xác định";
                }
            }
        }
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }
#endregion
#region "Metod - Function"
#endregion
    }
}
