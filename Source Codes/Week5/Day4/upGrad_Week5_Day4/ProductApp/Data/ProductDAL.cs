using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ProductApp.Data
{
    public class ProductDAL
    {
        private readonly string _connectionString;

        public ProductDAL(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        // INSERT
        public void InsertProduct(Product product)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Category", product.Category);
                cmd.Parameters.AddWithValue("@Price", product.Price);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // GET ALL
        public List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Product
                    {
                        ProductId = Convert.ToInt32(reader["ProductId"]),
                        ProductName = reader["ProductName"].ToString(),
                        Category = reader["Category"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"])
                    });
                }
            }

            return list;
        }

        // UPDATE
        public void UpdateProduct(Product product)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Category", product.Category);
                cmd.Parameters.AddWithValue("@Price", product.Price);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void DeleteProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}