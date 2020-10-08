﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get() //IEnumerable là interface (dạng kiểu mảng) có thể trả về list hoặc mảng 
        {
            // Lấy danh sách customer
            CustomerAccess cta = new CustomerAccess();
            return cta.GetData(); 
        }
        
        // GET api/<CustomerController>/5
        [HttpGet("{customerCode}")]
        public object Get(string customerCode)
        {
            // lấy thông tin 1 customer thông qua ustomerCode
            return null;
        }

        // POST api/<CustomerController>
        [HttpPost]
        //POST để thêm
        public bool Post([FromBody] Customer customer)
        {
            //if(customer != null)
            //{
            //    // tạo id cho customer mới
            //    customer.CustomerID = Guid.NewGuid();
            //    // thêm vào list
            //    Customer.CustomerList.Add(customer);
            //    return true;
            //}
            return false;
        }

        // PUT api/<CustomerController>/5
        //[HttpPut("{customerCode}")]
        // PUT để sửa
        public bool Put([FromBody] Customer customer)
        {
            //var customerEdit = Customer.CustomerList.Where(x => x.CustomerCode == customer.CustomerCode).FirstOrDefault();
            //if(customerEdit != null)
            //{
            //    customerEdit.CustomerName = customer.CustomerName;
            //    customerEdit.MemberCode = customer.MemberCode;
            //    customerEdit.MemberRank = customer.MemberRank;
            //    customerEdit.CustomerType = customer.CustomerType;
            //    customerEdit.Mobile = customer.Mobile;
            //    customerEdit.Birthday = customer.Birthday;
            //    customerEdit.CompanyName = customer.CompanyName;
            //    customerEdit.TaxCode = customer.TaxCode;
            //    customerEdit.Gender = customer.Gender;
            //    customerEdit.DebitMoney = customer.DebitMoney;
            //    customerEdit.Email = customer.Email;
            //    customerEdit.Address = customer.Address;
            //    customerEdit.Note = customer.Note;
            //    return true;
            //}
            return false;
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{strCustomerCode}")]
        public bool Delete(string strCustomerCode)
        {
            //string[] arr = strCustomerCode.Split(",");
            //bool check = true;
            //foreach (var customerCode in arr)
            //{
            //    var customerDelete = Customer.CustomerList.Where(x => x.CustomerCode == customerCode).FirstOrDefault();
            //    if (customerDelete != null)
            //    {
            //        Customer.CustomerList.Remove(customerDelete);
            //    }
            //    else
            //    {
            //        check = false;
            //    }
            //}
            return false;
        }
    }
}
