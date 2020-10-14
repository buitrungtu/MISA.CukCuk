using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Model
{
    public enum Gender
    {
        /// <summary>
        /// Nữ
        /// </summary>
        Female = 0,
        /// <summary>
        /// Nam
        /// </summary>
        Male = 1,
        /// <summary>
        /// Gay (Nam nhưng tính nữ)
        /// </summary>
        Gay = 2,
        /// <summary>
        /// Less (Nữ nhưng tính nam)
        /// </summary>
        Less = 3,
        /// <summary>
        /// Một giới tính không có khái niệm
        /// </summary>
        Other = 4
    }
    public enum WorkStatus {
        /// <summary>
        /// Đang làm việc
        /// </summary>
        Working = 0,
        /// <summary>
        /// Đã nghỉ việc
        /// </summary>
        Stopped =1,
        /// <summary>
        ///  Đang thử việc
        /// </summary>
        Waiting = 2,
        /// <summary>
        /// Sinh sản
        /// </summary>
        Childbirth = 3,
        /// <summary>
        /// Công tác nước ngoài
        /// </summary>
        Foreign = 4
    }
}
