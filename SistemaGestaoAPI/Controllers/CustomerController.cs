using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace SistemaGestaoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        public string ConnectionString { get; set; }

        private MySqlConnection GetConnection()
        {
            //return new MySqlConnection("Server=Localhost;Database=Sistema_Gestao;Uid=root;Pwd=#RocaGourmet2020;");
            return new MySqlConnection("Server=Localhost;Database=crud_db;Uid=root;Pwd=mysql@309389;");
        }

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [HttpGet("Get")]
        public List<Customer> Get()
        {
            List<Customer> customerList = new List<Customer>();

            using (MySqlConnection conn = GetConnection())
            {
                string sql = @"Select * From customer ";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.Id = Convert.ToInt32(reader["customer_id"]);
                        customer.Name = Convert.ToString(reader["customer_name"]);
                        customer.Phone1 = Convert.ToString(reader["customer_phone1"]);
                        customer.Phone2 = Convert.ToString(reader["customer_phone2"]);
                        customer.Address = Convert.ToString(reader["customer_address"]);
                        customer.DateBirthday = Convert.ToString(reader["customer_date_birthday"]);

                        customerList.Add(customer);
                    }
                }
                conn.Close();

            }

            return customerList;
        }

        [HttpGet("GetById")]
        public List<Customer> GetById(int id)
        {
            List<Customer> customerList = new List<Customer>();

            using (MySqlConnection conn = GetConnection())
            {
                string sql = @"Select * From customer where customer_id = " + id;

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.Id = Convert.ToInt32(reader["customer_id"]);
                        customer.Name = Convert.ToString(reader["customer_name"]);
                        customer.Phone1 = Convert.ToString(reader["customer_phone1"]);
                        customer.Phone2 = Convert.ToString(reader["customer_phone2"]);
                        customer.Address = Convert.ToString(reader["customer_address"]);
                        customer.DateBirthday = Convert.ToString(reader["customer_date_birthday"]);

                        customerList.Add(customer);
                    }
                }
                conn.Close();

            }

            return customerList;
        }

        [HttpGet("GetByName")]
        public List<Customer> GetByName(string name)
        {
            List<Customer> customerList = new List<Customer>();

            using (MySqlConnection conn = GetConnection())
            {
                string sql = @"Select * From customer where customer_name like '%" + name + "%'";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.Id = Convert.ToInt32(reader["customer_id"]);
                        customer.Name = Convert.ToString(reader["customer_name"]);
                        customer.Phone1 = Convert.ToString(reader["customer_phone1"]);
                        customer.Phone2 = Convert.ToString(reader["customer_phone2"]);
                        customer.Address = Convert.ToString(reader["customer_address"]);
                        customer.DateBirthday = Convert.ToString(reader["customer_date_birthday"]);

                        customerList.Add(customer);
                    }
                }
                conn.Close();

            }

            return customerList;
        }
    }
}
