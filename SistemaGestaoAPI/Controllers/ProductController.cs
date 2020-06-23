using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System.Xml;

namespace SistemaGestaoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public string ConnectionString { get; set; }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ProductController));
        //private static readonly string LOG_CONFIG_FILE = @"log4net.config";
        private static string nameLog  = "Método GetProduct - ";

        /*public static void Debug(object message)
        {
            SetLog4NetConfiguration();
            log.Debug(message);
        }

        public static void Info(object message)
        {
            SetLog4NetConfiguration();
            log.Info(message);
        }

        private static void SetLog4NetConfiguration()
        {
           XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(System.IO.File.OpenRead(LOG_CONFIG_FILE));

            var repo = log4net.LogManager.CreateRepository(
                System.Reflection.Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);


            var logRepo = log4net.LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            log4net.Config.XmlConfigurator.Configure(logRepo, new System.IO.FileInfo("log4net.config"));
        }*/

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection("Server=Localhost;Database=Sistema_Gestao;Uid=root;Pwd=#RocaGourmet2020;");
            //return new MySqlConnection("Server=Localhost;Database=crud_db;Uid=root;Pwd=mysql@309389;");
        }

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetProduct")]
        public Product GetProduct()
        {
            //SetLog4NetConfiguration();
            log.Debug(nameLog + "GetProduct - Entrou no método");

            Product product = new Product();

            using (MySqlConnection conn = GetConnection())
            {
                log.Debug(nameLog + "GetProduct - Consultando o BD");
                string sql = @"Select * From product where product_id = 10";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        product.Id = Convert.ToInt32(reader["product_id"]);
                        product.Name = Convert.ToString(reader["product_name"]);
                        product.PurchasePrice = Convert.ToDecimal(reader["product_purchase_price"]);
                        product.SalePrice = Convert.ToDecimal(reader["product_sale_price"]);
                        product.UnitOfmeasurement = Convert.ToString(reader["product_unit_of_measurement"]);
                        product.Stock = Convert.ToInt32(reader["product_stock"]);
                        product.Category = Convert.ToString(reader["product_category"]);
                    }
                }
                conn.Close();

            }

            log.Debug(nameLog + "GetProduct - Fim do método");

            return product;
        }

        [HttpGet("GetMessage")]
        public string GetMessage()
        {
            return "Mensagem retornada pela API";
        }

        [HttpGet("Get")]
        public List<Product> Get()
        {
            log.Debug(nameLog + "Get - Entrou no método");

            List<Product> productList = new List<Product>();

            using (MySqlConnection conn = GetConnection())
            {
                string sql = @"Select * From product ";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Id = Convert.ToInt32(reader["product_id"]);
                        product.Name = Convert.ToString(reader["product_name"]);
                        product.PurchasePrice = Convert.ToDecimal(reader["product_purchase_price"]);
                        product.SalePrice = Convert.ToDecimal(reader["product_sale_price"]);
                        product.UnitOfmeasurement = Convert.ToString(reader["product_unit_of_measurement"]);
                        product.Stock = Convert.ToInt32(reader["product_stock"]);
                        product.Category = Convert.ToString(reader["product_category"]);

                        productList.Add(product);
                    }
                }
                conn.Close();

            }

            log.Debug(nameLog + "Get - Fim do método");

            return productList;
        }

        [HttpGet("GetById")]
        public List<Product> GetById(int id)
        {
            log.Debug(nameLog + "GetById - Entrou no método");

            log.Debug(nameLog + "GetById - id = " + id);

            List<Product> productList = new List<Product>();

            using (MySqlConnection conn = GetConnection())
            {
                string sql = @"Select * From product where product_id = " + id;

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Id = Convert.ToInt32(reader["product_id"]);
                        product.Name = Convert.ToString(reader["product_name"]);
                        product.PurchasePrice = Convert.ToDecimal(reader["product_purchase_price"]);
                        product.SalePrice = Convert.ToDecimal(reader["product_sale_price"]);
                        product.UnitOfmeasurement = Convert.ToString(reader["product_unit_of_measurement"]);
                        product.Stock = Convert.ToInt32(reader["product_stock"]);
                        product.Category = Convert.ToString(reader["product_category"]);

                        productList.Add(product);
                    }
                }
                conn.Close();

            }

            log.Debug(nameLog + "GetById - Fim do método");

            return productList;
        }

        [HttpGet("GetByName")]
        public List<Product> GetByName(string[] name)
        {
            log.Debug(nameLog + "GetByName - Entrou no método");

            log.Debug(nameLog + "GetByName - name = " + name);

            List<Product> productList = new List<Product>();

            using (MySqlConnection conn = GetConnection())
            {
                string sql = @"Select * From product where product_name like '%" + name + "%'";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Id = Convert.ToInt32(reader["product_id"]);
                        product.Name = Convert.ToString(reader["product_name"]);
                        product.PurchasePrice = Convert.ToDecimal(reader["product_purchase_price"]);
                        product.SalePrice = Convert.ToDecimal(reader["product_sale_price"]);
                        product.UnitOfmeasurement = Convert.ToString(reader["product_unit_of_measurement"]);
                        product.Stock = Convert.ToInt32(reader["product_stock"]);
                        product.Category = Convert.ToString(reader["product_category"]);

                        productList.Add(product);
                    }
                }
                conn.Close();

            }

            log.Debug(nameLog + "GetByName - Fim do método");

            return productList;
        }
    }
}
