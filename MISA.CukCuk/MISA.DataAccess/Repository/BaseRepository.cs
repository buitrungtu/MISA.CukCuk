using MISA.DataAccess.Interface;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class BaseRepository<T>:IBaseRepository<T>
    {
        #region Property
        protected IDatabaseContext<T> _databaseContext;
        #endregion
        #region Constructor
        public BaseRepository(IDatabaseContext<T> databaseContext)
        {
            _databaseContext = databaseContext;
        }
        #endregion
        #region Method
        public IEnumerable<T> GetData()
        {
            return _databaseContext.GetData();
        }
        public IEnumerable<T> GetDataByPage(int page, int record)
        {
            return _databaseContext.GetDataByPage(page,record);
        }

        public T GetByID(object objID)
        {
            return _databaseContext.GetByID(objID);
        }
        public int Insert(T obj)
        {
            return _databaseContext.Insert(obj);
        }

        public int Update(T obj)
        {
            return _databaseContext.Update(obj);
        }
        public int Delete(Guid objID)
        {
            return _databaseContext.Delete(objID);
        }

        #endregion
    }
}
