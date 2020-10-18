using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    public class PagingObject
    {
        public int TotalPage { get; set; }
        public int TotalRecord { get; set; }
        public object Data { get; set; }
        public object AllData { get; set; }
        public string maxCode { get; set; }
    }
}
