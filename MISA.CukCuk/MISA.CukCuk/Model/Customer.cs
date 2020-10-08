﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Model
{
    public class Customer
    {
        
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
        private int Gender { get; set; }

        public string GenderName
        {
            get
            {
                switch (Gender)
                {
                    case 0:
                        return "Nữ";
                    case 1:
                        return "Nam";
                    case 2:
                        return "Gay";
                    case 3:
                        return "Less";
                    case 4:
                        return "Khác";
                    default:
                        return "Lưỡng tính";
                }
            }
            set
            {
                Gender = Int32.Parse(value);
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
