using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    public class Position
    {
        /// <summary>
        /// ID vị trí
        /// </summary>
        public Guid PositionID { get; set; }
       
        /// <summary>
        /// Mã vị trí
        /// </summary>
        public string PositionCode { get; set; }
        
        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string PositionName { get; set; }

    }
}
