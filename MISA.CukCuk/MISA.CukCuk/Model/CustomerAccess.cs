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
        public IEnumerable<Customer> GetData()
        {
            List<Customer> ListCustomer = new List<Customer>();
            OpenConnection();
            var mySqlCommand = conn.CreateCommand();
            mySqlCommand.CommandText = "SELECT * FROM View_Customer";
            MySqlDataReader mySqlDataReader=mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                var customer = new Customer();
                customer.CustomerID = mySqlDataReader.GetGuid(0);
                customer.CustomerCode = mySqlDataReader.GetString(1);
                customer.CustomerName = mySqlDataReader.GetString(2);
                if (!mySqlDataReader.IsDBNull(3))
                {
                    customer.Birthday = mySqlDataReader.GetDateTime(3);
                }
                else
                {
                    customer.Birthday = new DateTime();
                }
                customer.Mobile = mySqlDataReader.GetString(4);
                if (!mySqlDataReader.IsDBNull(5))
                {
                    customer.Address = mySqlDataReader.GetString(5);
                }
                else
                {
                    customer.Address = "";
                }
                if (!mySqlDataReader.IsDBNull(6))
                {
                    customer.Email = mySqlDataReader.GetString(6);
                }
                else
                {
                    customer.Email = "";
                }
                if (!mySqlDataReader.IsDBNull(7))
                {
                    customer.DebitMoney = mySqlDataReader.GetDouble(7);

                }
                else
                {
                    customer.DebitMoney = 0;
                }
                if (!mySqlDataReader.IsDBNull(8))
                {
                    customer.GenderName = mySqlDataReader.GetString(8);

                }
                else
                {
                    customer.GenderName = "";
                }
                ListCustomer.Add(customer);
            }
            mySqlDataReader.Close();
            return ListCustomer;
        }
    }
}
