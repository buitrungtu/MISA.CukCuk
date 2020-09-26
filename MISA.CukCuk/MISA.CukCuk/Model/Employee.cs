using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Model
{
    public class Employee
    {
        public static List<Employee> EmployeeList = new List<Employee>(){
            new Employee()
            {
                EmployeeCode = "KH001",
                EmployeeName = "Nguyễn Văn Mạnh",             
                Mobile = "0977340334",
                Birthday = new DateTime(1989,02,15),                
                Email = "manhnv@gmail.com",
                Gender="Nam",               
                Address = "Duy Tân, Cầu Giấy, Hà Nội",
                  PositionName = "Giám đốc",
                DepartmentName = "Đào tạo",
                Salary = 150000000,
                WorkStatus = "Đang làm việc"

            },
            new Employee()
            {
                EmployeeCode = "KH002",
                EmployeeName = "Lê Văn Thắng",           
                Mobile = "0971203341",
                Birthday = new DateTime(1993,11,11),
                Email = "thanglv@gmail.com",
                Gender="Nam",
                Address = "Hoàng Quốc Việt, Cầu Giấy, Hà Nội",
                PositionName = "Nhân viên",
                DepartmentName = "Sản xuất",
                Salary = 15000000,
                WorkStatus = "Đang làm việc"
            },
            new Employee()
            {
                EmployeeCode = "KH003",
                EmployeeName = "Nguyễn Thị Thu Hà",               
                Mobile = "0912213033",
                Birthday = new DateTime(1988,12,05),               
                Email = "hakhan7299@gmail.com",
                Gender="Nữ",             
                Address = "Tân Lập, Đan Phượng, Hà Nội",
                PositionName = "Nhân viên",
                DepartmentName = "Sản xuất",
                Salary = 15000000,
                WorkStatus = "Đang làm việc"
            },
            new Employee()
            {
                EmployeeCode = "KH004",
                EmployeeName = "Phan Tấn Trung",             
                Mobile = "0977340111",
                Birthday = new DateTime(1978,06,07),             
                Email = "chubethongminh@gmail.com",
                Gender="Nam",
                Address = "Minh Khai, Bắc Từ Liêm, Hà Nội",
                PositionName = "Nhân viên",
                DepartmentName = "Đào tạo",
                Salary = 15000000,
                WorkStatus = "Đang làm việc"
            },
            new Employee()
            {
                EmployeeCode = "KH005",
                EmployeeName = "Bùi Thị Trà My",           
                Mobile = "0977342544",
                Birthday = new DateTime(1998,02,07),           
                Email = "honghiquan@gmail.com",
                Gender="Nữ",            
                Address = "Phú Yên, An Lão, Hải Phòng",
                  PositionName = "Nhân viên",
                DepartmentName = "Sản xuất",
                Salary = 15000000,
                WorkStatus = "Đang làm việc"
            },
            new Employee()
            {
                EmployeeCode = "KH006",
                EmployeeName = "Đàm Thế Phong",             
                Mobile = "0971230334",
                Birthday = new DateTime(1997,10,11),
                Email = "hoangkyanh@gmail.com",
                Gender="Nam",
                Address = "Thượng Cát, Bắc Từ Liêm, Hà Nội",
                  PositionName = "Nhân viên",
                DepartmentName = "Đào tạo",
                Salary = 15000000,
                WorkStatus = "Đang làm việc"
            },
            new Employee()
            {
                EmployeeCode = "KH007",
                EmployeeName = "Hoàng Nghĩa Long",          
                Mobile = "0977343695",
                Birthday = new DateTime(1995,11,21),
                Email = "ironmonkey@gmail.com",
                Gender="Nam",
                Address = "Mỹ Đình, Nam Từ Liêm, Hà Nội",
                PositionName = "Nhân viên",
                DepartmentName = "Sản xuất",
                Salary = 15000000,
                WorkStatus = "Đã nghỉ việc"
            },
            new Employee()
            {
                EmployeeCode = "KH008",
                EmployeeName = "Nguyễn Duy Hiếu",
                Mobile = "0977323654",
                Birthday = new DateTime(1998,04,20),
                Email = "nguyensim@gmail.com",
                Gender="Nam",
                Address = "Mỹ Đình, Nam Từ Liêm, Hà Nội",
                PositionName = "Nhân viên",
                DepartmentName = "Sản xuất",
                Salary = 15000000,
                WorkStatus = "Đang làm việc"
            },
            new Employee()
            {
                EmployeeCode = "KH009",
                EmployeeName = "Lê Thế Nam",            
                Mobile = "0977132334",
                Birthday = new DateTime(1992,03,13),           
                Email = "wandotky@gmail.com",
                Gender="Nam",
                Address = "Hoài Đức A, Hoài Đức, Hà Nội",
                PositionName = "Nhân viên",
                DepartmentName = "Đào tạo",
                Salary = 15000000,
                WorkStatus = "Đang làm việc"
            },
            new Employee()
            {
                EmployeeCode = "KH010",
                EmployeeName = "Hoa Tất Thắng",          
                Mobile = "0977346321",
                Birthday = new DateTime(1991,08,06),            
                Email = "hoatat@gmail.com",
                Gender="Nam",
                Address = "Tây Tựu, Bắc Từ Liêm, Hà Nội",
                PositionName = "Nhân viên",
                DepartmentName = "Đào tạo",
                Salary = 15000000,
                WorkStatus = "Đang làm việc"
            }
        };

        #region "Constructor"
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public Employee()
        {
            EmployeeID = Guid.NewGuid();
        }
        #endregion
        #region "Property"
        /// <summary>
        /// Khóa chính (ID nhân viên)
        /// </summary>
        public Guid EmployeeID { get; set; }

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
        public string Gender { get; set; }

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
        public string PositionName { get; set; }

        /// <summary>
        /// Phòng ban
        /// </summary>
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
        public string WorkStatus { get; set; }
        #endregion
        #region "Metod - Function"
        #endregion
    }
}
