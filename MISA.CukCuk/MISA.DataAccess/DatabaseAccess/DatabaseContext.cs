using MISA.DataAccess.Interface;
using MISA.DataAccess.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.DataAccess.DatabaseAccess
{
    public class DatabaseContext<T>: IDisposable, IDatabaseContext<T>
    {
        #region Property
        readonly string _connectionString = "server=35.194.166.58;port=3306;user=nvmanh;password=12345678@Abc;database=MISACukCuk_F09_BTTu;Character Set=utf8";
        MySqlConnection _sqlConnection;
        MySqlCommand _sqlCommand;
        public DatabaseContext()
        {
            // Khởi tạo kết nối:
            _sqlConnection = new MySqlConnection(_connectionString);
            _sqlConnection.Open();
            // Đối tượng xử lý command:
            _sqlCommand = _sqlConnection.CreateCommand();
            _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        }
        #endregion
        #region Method
        #region Lấy dữ liệu
        public IEnumerable<T> GetDataByPage(int page, int record)
        {
            try
            {
                var objs = new List<T>();
                var className = typeof(T).Name; // Lấy ra kiểu dữ liệu
                _sqlCommand.CommandText = $"Proc_Get{className}sByPage";
                _sqlCommand.Parameters.AddWithValue("PageLimit", record);
                _sqlCommand.Parameters.AddWithValue("Count", page);

                MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    var obj = Activator.CreateInstance<T>(); // tạo 1 đối tượng

                    for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                    {
                        var columnName = mySqlDataReader.GetName(i); // lấy ra tên trường
                        var value = mySqlDataReader.GetValue(i); // lấy giá trị trường
                        var propertyInfo = obj.GetType().GetProperty(columnName); //Lấy ra property có tên là columnName
                        if (propertyInfo != null && value != DBNull.Value)
                            propertyInfo.SetValue(obj, value);
                    }
                    objs.Add(obj);
                }
                mySqlDataReader.Close();
                return objs;
            }
            catch
            {
                return null;
            }
            
        }
        public IEnumerable<T> GetData()
        {
            try
            {
                var objs = new List<T>();
                var className = typeof(T).Name;
                _sqlCommand.CommandText = $"Proc_Get{className}s";
                MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    var obj = Activator.CreateInstance<T>();

                    for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                    {
                        var columnName = mySqlDataReader.GetName(i);// lấy ra tên trường
                        var value = mySqlDataReader.GetValue(i);// lấy giá trị trường
                        var propertyInfo = obj.GetType().GetProperty(columnName);//Lấy ra property có tên là columnName
                        if (propertyInfo != null && value != DBNull.Value)
                            propertyInfo.SetValue(obj, value);
                    }
                    objs.Add(obj);
                }
                mySqlDataReader.Close();
                return objs;
            }
            catch
            {
                return null;
            }
            
        }

        public T GetByID(object objId)
        {
            try
            {
                var className = typeof(T).Name;
                _sqlCommand.CommandText = $"Proc_Get{className}ByID";
                MySqlCommandBuilder.DeriveParameters(_sqlCommand);
                if (_sqlCommand.Parameters.Count > 0)
                {
                    _sqlCommand.Parameters[0].Value = objId;
                }
                MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
                var obj = Activator.CreateInstance<T>();
                if (mySqlDataReader.Read())
                {
                    for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                    {
                        var columnName = mySqlDataReader.GetName(i);// lấy ra tên trường
                        var value = mySqlDataReader.GetValue(i);// lấy giá trị trường
                        var propertyInfo = obj.GetType().GetProperty(columnName);//Lấy ra property có tên là columnName
                        if (propertyInfo != null && value != DBNull.Value)
                            propertyInfo.SetValue(obj, value);
                    }
                }
                mySqlDataReader.Close();
                return obj;
            }
            catch
            {
                return default(T);
            }
            
        }
        public bool GetByCode(string code)
        {
            try
            {
                var objType = typeof(T).Name;
                _sqlCommand.CommandText = $"Proc_Get{objType}ByCode";
                MySqlCommandBuilder.DeriveParameters(_sqlCommand); //Lấy tham số của proc
                if (_sqlCommand.Parameters.Count > 0)
                {
                    _sqlCommand.Parameters[0].Value = code;
                }
                MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    mySqlDataReader.Close();
                    return true;
                }
                mySqlDataReader.Close();
                return false;
            }
            catch
            {
                return true;
            }
            
        }
        public string GetMaxEmployeeCode()
        {
            try
            {
                var objType = typeof(T).Name;
                _sqlCommand.CommandText = $"Proc_GetMax{objType}Code";
                return _sqlCommand.ExecuteScalar().ToString();
            }
            catch
            {
                return null;
            }
           
        }
        #endregion
        #region Thêm dữ liệu
        public int Insert(T obj)
        {
            try
            {
                var objType = typeof(T).Name;
                _sqlCommand.CommandText = $"Proc_Insert{objType}";
                MySqlCommandBuilder.DeriveParameters(_sqlCommand); //Lấy ra các tham số cần truyền của proc
                var parameters = _sqlCommand.Parameters;
                foreach (MySqlParameter param in parameters)
                {
                    var paramName = param.ParameterName.Replace("@", "");
                    //Lấy ra property có tên là paramName và không phân biệt hoa thường
                    var property = obj.GetType().GetProperty(paramName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (property != null)
                        param.Value = property.GetValue(obj);

                }
                var affectRows = _sqlCommand.ExecuteNonQuery();
                return affectRows;
            }
            catch
            {
                return 0;
            }
            
        }
        #endregion
        #region Sửa dữ liệu
        public int Update(T obj)
        {
            try
            {
                var objType = typeof(T).Name;
                _sqlCommand.CommandText = $"Proc_Update{objType}";
                MySqlCommandBuilder.DeriveParameters(_sqlCommand);//Lấy ra các tham số cần truyền của proc
                var parameters = _sqlCommand.Parameters;
                foreach (MySqlParameter param in parameters)
                {
                    var paramName = param.ParameterName.Replace("@", "");
                    //Lấy ra property có tên là paramName và không phân biệt hoa thường
                    var property = obj.GetType().GetProperty(paramName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (property != null)
                        param.Value = property.GetValue(obj);

                }
                var affectRows = _sqlCommand.ExecuteNonQuery();
                return affectRows;
            }
            catch
            {
                return 0;
            }
           
        }

        #endregion
        #region Xóa dữ liệu
        public int Delete(Guid objId)
        {
            try
            {
                var objType = typeof(T).Name;
                _sqlCommand.CommandText = $"Proc_Delete{objType}";
                MySqlCommandBuilder.DeriveParameters(_sqlCommand);//Lấy ra các tham số cần truyền của proc
                if (_sqlCommand.Parameters.Count > 0)
                {
                    _sqlCommand.Parameters[0].Value = objId;
                }
                var affectRows = _sqlCommand.ExecuteNonQuery();
                return affectRows;
            }
            catch
            {
                return 0;
            }
            
        }
        #endregion
        #endregion

        //Đóng kết nối
        public void Dispose()
        {
            _sqlConnection.Close();
        }

        
    } 
}
