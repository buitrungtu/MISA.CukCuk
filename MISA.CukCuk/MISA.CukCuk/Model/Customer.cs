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
                Birdday = "1/1/1990",
                CompanyName = "Công ty cổ phần MISA",
                TaxCode = "",
                Email = "manhnv@gmail.com",
                Address = "Cầu Giấy, Hà Nội",
                Note = ""
            },
            new Customer()
            {
                CustomerCode = "KH002",
                CustomerName = "Lê Văn Thắng",
                MemberCode = "MB002",
                MemberRank = "1",
                CustomerType = "1",
                Mobile = "097120334",
                Birdday = "1/1/1986",
                CompanyName = "Công ty cổ phần Vinamilk",
                TaxCode = "",
                Email = "thanglv@gmail.com",
                Address = "Cầu Giấy, Hà Nội",
                Note = ""
            },
            new Customer()
            {
                CustomerCode = "KH003",
                CustomerName = "Nguyễn Thị Thu Hà",
                MemberCode = "MB003",
                MemberRank = "1",
                CustomerType = "3",
                Mobile = "09122130334",
                Birdday = "1/1/1999",
                CompanyName = "Công ty cổ phần MTA",
                TaxCode = "",
                Email = "hakhan7299@gmail.com",
                Address = "Đan Phượng, Hà Nội",
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
                Birdday = "1/1/2006",
                CompanyName = "Công ty cổ phần BAROI",
                TaxCode = "",
                Email = "chubedan@gmail.com",
                Address = "Bắc Từ Liêm, Hà Nội",
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
                Birdday = "1/1/1990",
                CompanyName = "Công ty Phật Sơn",
                TaxCode = "",
                Email = "honghiquan@gmail.com",
                Address = "Kon Tumb, Dark Lak",
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
                Birdday = "1/1/1959",
                CompanyName = "Công ty Phật Sơn",
                TaxCode = "",
                Email = "hoangkyanh@gmail.com",
                Address = "Bắc Từ Liêm, Hà Nội",
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
                Birdday = "1/1/1972",
                CompanyName = "Công ty Thifbest",
                TaxCode = "",
                Email = "ironmonkey@gmail.com",
                Address = "Nam Từ Liêm, Hà Nội",
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
                Birdday = "1/1/1988",
                CompanyName = "Công ty cổ phần MISA",
                TaxCode = "",
                Email = "nguyensim@gmail.com",
                Address = "Nam Từ Liêm, Hà Nội",
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
                Birdday = "1/1/1990",
                CompanyName = "Công ty BKAV",
                TaxCode = "",
                Email = "wandotky@gmail.com",
                Address = "Hoài Đức, Hà Nội",
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
                Birdday = "1/1/1990",
                CompanyName = "Công ty Toàn Chân",
                TaxCode = "",
                Email = "chibinh@gmail.com",
                Address = "Phố Hoa, Đà Nẵng",
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
        /// Điện thoại di động
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public string Birdday { get; set; }

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
