using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    public class DialogInformation
    {
        /// <summary>
        /// Giá trị mã lớn nhất hiện tại
        /// </summary>
        /// Author: BTTu (19/10/2020)
        public string MaxCode { get; set; }

        public IDictionary<Guid, string> DicDepartment = new Dictionary<Guid, string>();

        public IDictionary<Guid, string> DicPosition = new Dictionary<Guid, string>();

    }
}
