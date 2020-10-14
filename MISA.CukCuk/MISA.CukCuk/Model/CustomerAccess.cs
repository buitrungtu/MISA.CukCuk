using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace MISA.CukCuk.Model
{
    public class CustomerAccess:DatabaseAccess
    {
        public IEnumerable<Customer> GetData(int pageLimit, int count)
        {
            var ListCustomer = new List<Customer>();
            OpenConnection();
            var mySqlCommand = conn.CreateCommand();
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            mySqlCommand.CommandText = "Proc_GetCustomers";

            mySqlCommand.Parameters.Add("PageLimit", MySqlDbType.Int32).Value = pageLimit;
            mySqlCommand.Parameters.Add("Count", MySqlDbType.Int32).Value = count;

            MySqlDataReader mySqlDataReader=mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                var customer = new Customer();
                for(int i = 0; i < mySqlDataReader.FieldCount; i++)
                {
                    // lấy tên cột dữ liệu
                    var colName = mySqlDataReader.GetName(i);
                    // lấy giá trị cell đang đọc
                    var value = mySqlDataReader.GetValue(i);
                    // Lấy ra property giống với tên cột được khai báo ở trên
                    var property = customer.GetType().GetProperty(colName);
                    // nếu có property tương ứng thì gán dữ liệu tương ứng
                    if(property != null && value != DBNull.Value)
                    {
                        property.SetValue(customer, value);
                    }
                }
                ListCustomer.Add(customer);
            }
            mySqlDataReader.Close();
            return ListCustomer;
        }
        public bool InsertCustomer(Customer customer) 
        {
            OpenConnection();
            var mySqlCommand = conn.CreateCommand();
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            mySqlCommand.CommandText = "Proc_InsertCustomer";
            mySqlCommand.Parameters.Add("CustomerCode", MySqlDbType.VarChar).Value = customer.CustomerCode;
            mySqlCommand.Parameters.Add("CustomerName", MySqlDbType.VarChar).Value = customer.CustomerName;
            mySqlCommand.Parameters.Add("Birthday", MySqlDbType.Date).Value = customer.Birthday;
            mySqlCommand.Parameters.Add("Mobile", MySqlDbType.VarChar).Value = customer.Mobile;
            mySqlCommand.Parameters.Add("Address", MySqlDbType.VarChar).Value = customer.Address;
            mySqlCommand.Parameters.Add("Email", MySqlDbType.VarChar).Value = customer.Email;
            mySqlCommand.Parameters.Add("DebitAmount", MySqlDbType.Double).Value = customer.DebitAmount;
            mySqlCommand.Parameters.Add("CompanyName", MySqlDbType.VarChar).Value = customer.CompanyName;
            mySqlCommand.Parameters.Add("TaxCode", MySqlDbType.VarChar).Value = customer.TaxCode;
            mySqlCommand.Parameters.Add("Note", MySqlDbType.VarChar).Value = customer.Note;
            mySqlCommand.Parameters.Add("MemberCode", MySqlDbType.VarChar).Value = customer.MemberCode;
            mySqlCommand.Parameters.Add("CustormerType", MySqlDbType.Int32).Value = customer.CustomerType;
            mySqlCommand.Parameters.Add("Gender", MySqlDbType.Int32).Value = customer.Gender;
            mySqlCommand.Parameters.Add("CreatedBy", MySqlDbType.VarChar).Value = "Bùi Trung Tú";
            int response = mySqlCommand.ExecuteNonQuery();
            if (response > 0) return true;
            return false;
        }
        public Customer GetCustomerByID(string customerID)
        {
            var customer = new Customer();
            OpenConnection();
            var mySqlCommand = conn.CreateCommand();
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            mySqlCommand.CommandText = "Proc_GetCustomerByID";

            mySqlCommand.Parameters.Add("CustomerID", MySqlDbType.VarChar).Value = customerID;

            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            if (mySqlDataReader.Read())
            {
                for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                {
                    // lấy tên cột dữ liệu
                    var colName = mySqlDataReader.GetName(i);
                    // lấy giá trị cell đang đọc
                    var value = mySqlDataReader.GetValue(i);
                    // Lấy ra property giống với tên cột được khai báo ở trên
                    var property = customer.GetType().GetProperty(colName);
                    // nếu có property tương ứng thì gán dữ liệu tương ứng
                    if (property != null && value != DBNull.Value)
                    {
                        property.SetValue(customer, value);
                    }
                }
            }
            return customer;
        }
        public bool UpdateCustomer(Customer customer)
        {
            OpenConnection();
            var mySqlCommand = conn.CreateCommand();
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            mySqlCommand.CommandText = "Proc_UpdateCustomer";
            mySqlCommand.Parameters.Add("CustomerID", MySqlDbType.VarChar).Value = customer.CustomerID;
            mySqlCommand.Parameters.Add("CustomerCode", MySqlDbType.VarChar).Value = customer.CustomerCode;
            mySqlCommand.Parameters.Add("CustomerName", MySqlDbType.VarChar).Value = customer.CustomerName;
            mySqlCommand.Parameters.Add("Birthday", MySqlDbType.Date).Value = customer.Birthday;
            mySqlCommand.Parameters.Add("Mobile", MySqlDbType.VarChar).Value = customer.Mobile;
            mySqlCommand.Parameters.Add("Address", MySqlDbType.VarChar).Value = customer.Address;
            mySqlCommand.Parameters.Add("Email", MySqlDbType.VarChar).Value = customer.Email;
            mySqlCommand.Parameters.Add("DebitAmount", MySqlDbType.Double).Value = customer.DebitAmount;
            mySqlCommand.Parameters.Add("CompanyName", MySqlDbType.VarChar).Value = customer.CompanyName;
            mySqlCommand.Parameters.Add("TaxCode", MySqlDbType.VarChar).Value = customer.TaxCode;
            mySqlCommand.Parameters.Add("Note", MySqlDbType.VarChar).Value = customer.Note;
            mySqlCommand.Parameters.Add("MemberCode", MySqlDbType.VarChar).Value = customer.MemberCode;
            mySqlCommand.Parameters.Add("CustormerType", MySqlDbType.Int32).Value = customer.CustomerType;
            mySqlCommand.Parameters.Add("Gender", MySqlDbType.Int32).Value = customer.Gender;
            mySqlCommand.Parameters.Add("ModifyBy", MySqlDbType.VarChar).Value = "Bùi Trung Tú";
            int response = mySqlCommand.ExecuteNonQuery();
            if (response > 0) return true;
            return false;
        }
        public bool DeleteCustomer(string customerID)
        {
            OpenConnection();
            var mySqlCommand = conn.CreateCommand();
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            mySqlCommand.CommandText = "Proc_DeleteCustomer";
            mySqlCommand.Parameters.Add("Customer_CustomerID", MySqlDbType.VarChar).Value = customerID;
            int response = mySqlCommand.ExecuteNonQuery();
            if (response > 0) return true;
            return false;
        }
    }
}
