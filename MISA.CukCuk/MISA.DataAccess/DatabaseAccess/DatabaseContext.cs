﻿using MISA.DataAccess.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;
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
                var obj = Activator.CreateInstance<T>();
             
                for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                {
                    var columnName = mySqlDataReader.GetName(i);
                    var value = mySqlDataReader.GetValue(i);
                    var propertyInfo = obj.GetType().GetProperty(columnName);
                    if (propertyInfo != null && value != DBNull.Value)
                        propertyInfo.SetValue(obj, value);
                }
                employees.Add(obj);
            }
           
            return employees;
        }
       

        public T GetById(object objId)
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
                    var columnName = mySqlDataReader.GetName(i);
                    var value = mySqlDataReader.GetValue(i);
                    var propertyInfo = obj.GetType().GetProperty(columnName);
                    if (propertyInfo != null && value != DBNull.Value)
                        propertyInfo.SetValue(obj, value);
                }
            }
            return obj;
        }

        public int Insert(T obj)
        {
            var objType = typeof(T).Name;
            _sqlCommand.CommandText = $"Proc_Insert{objType}";
            MySqlCommandBuilder.DeriveParameters(_sqlCommand);
            var parameters = _sqlCommand.Parameters;
            foreach(MySqlParameter param in parameters)
            {
                var paramName = param.ParameterName.Replace("@", "");
                var property = obj.GetType().GetProperty(paramName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property != null)
                    param.Value = property.GetValue(obj);

            }
            var affectRows = _sqlCommand.ExecuteNonQuery();
            return affectRows;
        }

        public int Update(T obj)
        {
            var objType = typeof(T).Name;
            _sqlCommand.CommandText = $"Proc_Update{objType}";
            MySqlCommandBuilder.DeriveParameters(_sqlCommand);
            var parameters = _sqlCommand.Parameters;
            foreach (MySqlParameter param in parameters)
            {
                var paramName = param.ParameterName.Replace("@", "");
                var property = obj.GetType().GetProperty(paramName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property != null)
                    param.Value = property.GetValue(obj);

            }
            var affectRows = _sqlCommand.ExecuteNonQuery();
            return affectRows;
        }

        public int Delete(Guid objId)
        {
            var objType = typeof(T).Name;
            _sqlCommand.CommandText = $"Proc_Delete{objType}";
            MySqlCommandBuilder.DeriveParameters(_sqlCommand);
            if (_sqlCommand.Parameters.Count > 0)
            {
                _sqlCommand.Parameters[0].Value = objId;
            }
            var affectRows = _sqlCommand.ExecuteNonQuery();
            return affectRows;
        }

        public void Dispose()
        {
            _sqlConnection.Close();
        }
    } 
}
