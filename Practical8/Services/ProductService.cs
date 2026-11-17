using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Practical8.Models;    

namespace Practical8.Services
{
   
        public class ProductService
        {
            private string connectionString =
                ConfigurationManager.ConnectionStrings["InventoryConnection"].ConnectionString;

            // READ: Get all products
            public List<Product> GetAll()
            {
                List<Product> products = new List<Product>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Products";

                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = Convert.ToInt32(reader["ProductId"]),
                            ProductName = reader["ProductName"].ToString(),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            Category = reader["Category"].ToString()
                        });
                    }
                }

                return products;
            }

            // READ: Get product by ID
            public Product GetById(int id)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Products WHERE ProductId=@id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Product
                        {
                            ProductId = Convert.ToInt32(reader["ProductId"]),
                            ProductName = reader["ProductName"].ToString(),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            Category = reader["Category"].ToString()
                        };
                    }
                }

                return null;
            }

            // CREATE: Add product
            public void Add(Product p)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Products
                (ProductName, Quantity, Price, Category)
                VALUES (@name, @quantity, @price, @category)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@name", p.ProductName);
                    cmd.Parameters.AddWithValue("@quantity", p.Quantity);
                    cmd.Parameters.AddWithValue("@price", p.Price);
                    cmd.Parameters.AddWithValue("@category", p.Category);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // UPDATE: Edit product
            public void Update(Product p)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE Products SET
                ProductName=@name,
                Quantity=@quantity,
                Price=@price,
                Category=@category
                WHERE ProductId=@id";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@id", p.ProductId);
                    cmd.Parameters.AddWithValue("@name", p.ProductName);
                    cmd.Parameters.AddWithValue("@quantity", p.Quantity);
                    cmd.Parameters.AddWithValue("@price", p.Price);
                    cmd.Parameters.AddWithValue("@category", p.Category);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // DELETE: Remove product
            public void Delete(int id)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Products WHERE ProductId=@id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
