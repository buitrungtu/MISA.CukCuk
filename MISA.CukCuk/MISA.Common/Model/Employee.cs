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
        public Guid PositionID { get; set; }
        public string PositionName { get; set; }

        /// <summary>
        /// Phòng ban
        /// </summary>
        public Guid DepartmentID { get; set; }
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
        /// Số chứng minh thư nhân nhân / hộ chiếu
        /// </summary>
        public string Identity { get; set; }

        /// <summary>
        /// Ngày cấp chứng minh thư / hộ chiếu
        /// </summary>
        public DateTime IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp chứng minh thư / Hộ chiếu
        /// </summary>
        public string IdentityPlace { get; set; }

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
                        return "Nghỉ sinh sản";
                    case WorkStatus.Foreign:
                        return "Công tác nước ngoài";
                    default:
                        return "Không xác định";
                }
            }
        }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string TaxCode { get; set; }

        /// <summary>
        /// Ngày gia nhập
        /// </summary>
        public DateTime JoinDate { get; set; }

        /// <summary>
        /// Link ảnh đại diện
        /// </summary>
        public string LinkAvatar { get; set; }
        #endregion
        #region Metod
        #endregion
    }
}
