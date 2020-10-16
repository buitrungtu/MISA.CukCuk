using MISA.DataAccess.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.DatabaseAccess
{
    public class DatabaseContext<T>: IDisposable, IBaseRepository<T>
    {
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
        public IEnumerable<T> Get()
        {
            var employees = new List<T>();
            var className = typeof(T).Name;
            _sqlCommand.CommandText = $"Proc_Get{className}s";
            _sqlCommand.Parameters.AddWithValue("PageLimit", 10);
            _sqlCommand.Parameters.AddWithValue("Count", 0);

            MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                var employee = Activator.CreateInstance<T>();
             
                for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                {
                    var columnName = mySqlDataReader.GetName(i);
                    var value = mySqlDataReader.GetValue(i);
                    var propertyInfo = employee.GetType().GetProperty(columnName);
                    if (propertyInfo != null && value != DBNull.Value)
                        propertyInfo.SetValue(employee, value);
                }
                employees.Add(employee);
            }
           
            return employees;
        }
        public void Dispose()
        {
            _sqlConnection.Close();
        }

        public T GetById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public int Insert(T employee)
        {
            throw new NotImplementedException();
        }

        public int Update(T employee)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    } 
}
