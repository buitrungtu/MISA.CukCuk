using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Model
{
    public class Customer
    {
        #region "DECLARE"
        public static List<Customer> CustomerList = new List<Customer>(){
            new Customer()
            {
                CustomerCode = "KH001",
                CustomerName = "Nguyễn Văn Mạnh",
                MemberCode = "MB001",
                MemberRank = "1",
                CustomerType = "1",
                Mobile = "0977340334",
                Birthday = new DateTime(1989,2,15),
                CompanyName = "Công ty cổ phần MISA",
                TaxCode = "",
                Email = "manhnv@gmail.com",
                Gender="Nam",
                DebitMoney = 10000000,
                Address = "Duy Tân, Cầu Giấy, Hà Nội",
                Note = ""
            },
            new Customer()
            {
                CustomerCode = "KH002",
                CustomerName = "Lê Văn Thắng",
                MemberCode = "MB002",
                MemberRank = "1",
                CustomerType = "1",
                Mobile = "0971203341",
                Birthday = new DateTime(1993,11,11),
                CompanyName = "Công ty cổ phần Vinamilk",
                TaxCode = "",
                Email = "thanglv@gmail.com",
                Gender="Nam",
                DebitMoney = 12000000,
                Address = "Hoàng Quốc Việt, Cầu Giấy, Hà Nội",
                Note = ""
            },
            new Customer()
            {
                CustomerCode = "KH003",
                CustomerName = "Nguyễn Thị Thu Hà",
                MemberCode = "MB003",
                MemberRank = "1",
                CustomerType = "3",
                Mobile = "0912213033",
                Birthday = new DateTime(1988,12,5),
                CompanyName = "Công ty cổ phần Sun Homie",
                TaxCode = "",
                Email = "hakhan7299@gmail.com",
                Gender="Nữ",
                DebitMoney = 1200000,
                Address = "Tân Lập, Đan Phượng, Hà Nội",
                Note = ""
            },
            new Customer()
            {
                CustomerCode = "KH004",
                CustomerName = "Phan Tấn Trung",
                MemberCode = "MB004",
                MemberRank = "2",
                CustomerType = "1",
                Mobile = "0977340111",
                Birthday = new DateTime(1978,6,7),
                CompanyName = "Công ty cổ phần SBTC",
                TaxCode = "",
                Email = "chubethongminh@gmail.com",
                Gender="Nam",
                DebitMoney = 120000000,
                Address = "Minh Khai, Bắc Từ Liêm, Hà Nội",
                Note = ""
            },
            new Customer()
            {
                CustomerCode = "KH005",
                CustomerName = "Bùi Thị Trà My",
                MemberCode = "MB005",
                MemberRank = "2",
                CustomerType = "1",
                Mobile = "0977342544",
                Birthday = new DateTime(1998,2,7),
                CompanyName = "Công ty Viettel Telecom",
                TaxCode = "",
                Email = "honghiquan@gmail.com",
                Gender="Nữ",
                DebitMoney = 500000,
                Address = "Phú Yên, An Lão, Hải Phòng",
                Note = ""
            },
            new Customer()
            {
                CustomerCode = "KH006",
                CustomerName = "Đàm Thế Phong",
                MemberCode = "MB006",
                MemberRank = "3",
                CustomerType = "3",
                Mobile = "0971230334",
                Birthday = new DateTime(1997,10,11),
                CompanyName = "Công ty HocMai Education",
                TaxCode = "",
                Email = "hoangkyanh@gmail.com",
                Gender="Nam",
                DebitMoney = 1500000000,
                Address = "Thượng Cát, Bắc Từ Liêm, Hà Nội",
                Note = ""
            },
            new Customer()
            {
                CustomerCode = "KH007",
                CustomerName = "Hoàng Nghĩa Long",
                MemberCode = "MB007",
                MemberRank = "2",
                CustomerType = "1",
                Mobile = "0977343695",
                Birthday = new DateTime(1995,11,21),
                CompanyName = "Công ty cổ phần Vibex",
                TaxCode = "",
                Email = "ironmonkey@gmail.com",
                Gender="Nam",
                DebitMoney = 21000000,
                Address = "Mỹ Đình, Nam Từ Liêm, Hà Nội",
                Note = ""
            },
            new Customer()
            {
                CustomerCode = "KH008",
                CustomerName = "Nguyễn Duy Hiếu",
                MemberCode = "MB008",
                MemberRank = "1",
                CustomerType = "1",
                Mobile = "0977323654",
                Birthday = new DateTime(1998,4,20),
                CompanyName = "Công ty cổ phần Hoa Vy",
                TaxCode = "",
                Email = "nguyensim@gmail.com",
                Gender="Nam",
                DebitMoney = 35000000,
                Address = "Mỹ Đình, Nam Từ Liêm, Hà Nội",
                Note = ""
            },
            new Customer()
            {
                CustomerCode = "KH009",
                CustomerName = "Lê Thế Nam",
                MemberCode = "MB009",
                MemberRank = "2",
                CustomerType = "1",
                Mobile = "0977132334",
                Birthday = new DateTime(1992,3,13),
                CompanyName = "Công ty cổ phần Toàn Phát",
                TaxCode = "",
                Email = "wandotky@gmail.com",
                Gender="Nam",
                DebitMoney = 190000000,
                Address = "Hoài Đức A, Hoài Đức, Hà Nội",
                Note = ""
            },
            new Customer()
            {
                CustomerCode = "KH010",
                CustomerName = "Hoa Tất Thắng",
                MemberCode = "MB010",
                MemberRank = "2",
                CustomerType = "1",
                Mobile = "0977346321",
                Birthday = new DateTime(1991,8,6),
                CompanyName = "Công ty FPT Software",
                TaxCode = "",
                Email = "hoatat@gmail.com",
                Gender="Nam",
                DebitMoney = 9000000,
                Address = "Tây Tựu, Bắc Từ Liêm, Hà Nội",
                Note = ""
            }
        };
        #endregion

        #region "Constructor"
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public Customer()
        {
            CustomerID = Guid.NewGuid();
        }
        #endregion

        #region "Property"
        /// <summary>
        /// Khóa chính (ID khách hàng)
        /// </summary>
        public Guid? CustomerID { get; set; } // sinh ra 36 ký tự, là duy nhất trên thế giới

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Mã thẻ thành viên
        /// </summary>
        public string MemberCode { get; set; }

        /// <summary>
        /// Hạng thẻ
        /// </summary>
        public string MemberRank { get; set; }

        /// <summary>
        /// Nhóm khách hàng
        /// </summary>
        public string CustomerType { get; set; }

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
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string TaxCode { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Số tiền nợ
        /// </summary>
        public double DebitMoney { get; set; }


        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }
        #endregion

        #region "Metod - Function"
        #endregion
    }
}
