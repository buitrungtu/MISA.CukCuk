using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Interface
{
    public interface IBaseRepository<T>
    {

        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// Author: BTTu (15/10/2020)
        /// <returns></returns>
        IEnumerable<T> GetData();

        /// <summary>
        /// Lấy dữ liệu và phân trang
        /// </summary>
        /// <param name="page">trang</param>
        /// <param name="record">số bản ghi trong 1 trang</param>
        /// Author: BTTu (15/10/2020)
        /// <returns></returns>
        IEnumerable<T> GetDataByPage(int page, int record);

        /// <summary>
        /// Lấy dữ liệu của 1 đối tượng
        /// </summary>
        /// <param name="objID">ID của T</param>
        /// Author: BTTu (15/10/2020)
        /// <returns></returns>
        T GetByID(object objID);

        /// <summary>
        /// Thêm mới 1 đối tượng
        /// </summary>
        /// <param name="obj">T</param>
        /// Author: BTTu (15/10/2020)
        /// <returns></returns>
        int Insert(T obj);

        /// <summary>
        /// Sửa dữ liệu 1 đối tượng
        /// </summary>
        /// <param name="obj">T</param>
        /// Author: BTTu (15/10/2020)
        /// <returns></returns>
        int Update(T obj);

        /// <summary>
        /// Xóa 1 đối tượng
        /// </summary>
        /// <param name="objID">ID của T</param>
        /// Author: BTTu (15/10/2020)
        /// <returns></returns>
        int Delete(Guid objID);
    }
}
