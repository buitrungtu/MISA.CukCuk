using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Interfaces
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// Author: Bui Trung Tu (15/10/2020)
        /// <returns></returns>
        IEnumerable<T> GetData();
        /// <summary>
        /// Lấy dữ liệu có phân trang
        /// </summary>
        /// Author: Bui Trung Tu (15/10/2020)
        /// <returns></returns>
        IEnumerable<T> GetDataByPage(int page,int record);

        /// <summary>
        /// Lấy dữ liệu của đối tượng
        /// </summary>
        /// <param name="objId">ID của T</param>
        /// Author: Bui Trung Tu (15/10/2020)
        /// <returns></returns>
        T GetById(object pbjId);

        /// <summary>
        /// Thêm 1 đối tượng
        /// </summary>
        /// <param name="obj">T</param>
        /// Author: Bui Trung Tu (15/10/2020)
        /// <returns></returns>
        ServiceResponse Insert(T obj);

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="obj">T</param>
        /// Author: Bui Trung Tu (15/10/2020)
        /// <returns></returns>
        ServiceResponse Update(T obj);

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="objId">ID của T</param>
        /// Author: Bui Trung Tu (15/10/2020)
        /// <returns></returns>
        ServiceResponse Delete(Guid objId);
    }
}
