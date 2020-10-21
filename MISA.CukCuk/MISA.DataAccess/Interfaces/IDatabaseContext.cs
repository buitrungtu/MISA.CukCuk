using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Interfaces
{
    public interface IDatabaseContext<T>
    {
        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// Author:BTTu (19/10/2020)
        /// <returns></returns>
        IEnumerable<T> GetData();
        /// <summary>
        /// Lấy dữ liệu theo trang và giới hạn bản ghi
        /// </summary>
        /// <param name="page">trang</param>
        /// <param name="record">bản ghi trong 1 trang</param>
        /// Author:BTTu (19/10/2020)
        /// <returns></returns>
        IEnumerable<T> GetDataByPage(int page, int record);

        /// <summary>
        /// Lấy dữ liệu thông qua id
        /// </summary>
        /// <param name="objId">id</param>
        /// Author:BTTu (19/10/2020)
        /// <returns></returns>
        T GetByID(object objId);

        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="obj">đối tượng thêm</param>
        /// Author:BTTu (19/10/2020)
        /// <returns></returns>
        int Insert(T obj);

        /// <summary>
        /// Sửa thông tin
        /// </summary>
        /// <param name="obj">đối tượng</param>
        /// Author:BTTu (19/10/2020)
        /// <returns></returns>
        int Update(T obj);

        /// <summary>
        /// Xóa bản ghi thông qua id
        /// </summary>
        /// <param name="objID">id</param>
        /// Author:BTTu (19/10/2020)
        /// <returns></returns>
        int Delete(Guid objID);

        /// <summary>
        /// Lấy dữ liệu thông qua mã 
        /// </summary>
        /// <param name="objCode">mã</param>
        /// Author:BTTu (19/10/2020)
        /// <returns></returns>
        bool GetByCode(string objCode);

        /// <summary>
        /// Lấy ra mã lớn nhất
        /// </summary>
        /// Author:BTTu (19/10/2020)
        /// <returns></returns>
        string GetMaxEmployeeCode();
    }
}
