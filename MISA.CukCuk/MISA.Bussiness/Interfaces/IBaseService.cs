﻿using System;
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
        IEnumerable<T> Get();

        /// <summary>
        /// Lấy dữ liệu của đối tượng
        /// </summary>
        /// <param name="objId">ID của T</param>
        /// Author: Bui Trung Tu (15/10/2020)
        /// <returns></returns>
        T GetById(Guid pbjId);

        /// <summary>
        /// Thêm 1 đối tượng
        /// </summary>
        /// <param name="obj">T</param>
        /// Author: Bui Trung Tu (15/10/2020)
        /// <returns></returns>
        int Insert(T obj);

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="obj">T</param>
        /// Author: Bui Trung Tu (15/10/2020)
        /// <returns></returns>
        int Update(T obj);

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="objId">ID của T</param>
        /// Author: Bui Trung Tu (15/10/2020)
        /// <returns></returns>
        int Delete(Guid objId);
    }
}
