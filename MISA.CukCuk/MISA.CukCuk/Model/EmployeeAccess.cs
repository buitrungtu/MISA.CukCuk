using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace MISA.CukCuk.Model
{
    public class EmployeeAccess:DatabaseAccess
    {
        public IEnumerable<Employee> GetData(int pageLimit, int count)
        {
            var ListEmployee = new List<Employee>();
            OpenConnection();
            var mySqlCommand = conn.CreateCommand();
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            mySqlCommand.CommandText = "Proc_GetEmployees";

            mySqlCommand.Parameters.Add("PageLimit", MySqlDbType.Int32).Value = pageLimit;
            mySqlCommand.Parameters.Add("Count", MySqlDbType.Int32).Value = count;

            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                var employee = new Employee();
                for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                {
                    // lấy tên cột dữ liệu
                    var colName = mySqlDataReader.GetName(i);
                    // lấy giá trị cell đang đọc
                    var value = mySqlDataReader.GetValue(i);
                    // Lấy ra property giống với tên cột được khai báo ở trên
                    var property = employee.GetType().GetProperty(colName);
                    // nếu có property tương ứng thì gán dữ liệu tương ứng
                    if (property != null && value != DBNull.Value)
                    {
                        property.SetValue(employee, value);
                    }
                }
                ListEmployee.Add(employee);
            }
            mySqlDataReader.Close();
            return ListEmployee;
        }
    }
}
