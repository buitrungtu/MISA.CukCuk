using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    public class ServiceResponse
    {
        /// <summary>
        /// Thông báo
        /// </summary>
        public List<string> Msg { get; set; } = new List<string>();
        
        /// <summary>
        /// Thành công
        /// </summary>
        public bool Success { get; set; }
        
        /// <summary>
        /// Dữ liệu
        /// </summary>
        public object Data { get; set; }
    }
}
