using FullStackPK.Entities;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace FullStackPK.Reposatories
{
    public class ProductRepo : IProductRepo
    {
       public string DeleteById(int id)
        {
            string conString = "server=localhost; port=3306; username=root; password=pragati; database=dotnet";
            MySqlConnection connection =new MySqlConnection(conString);
            string query = "delete from products where product_id=@value1";
            try {
                connection.Open();
                MySqlCommand cmd= new MySqlCommand(query,connection);
                cmd.Parameters.AddWithValue("@value1", id);
                int res = cmd.ExecuteNonQuery();
                if (res == 0) {
                    return "cou;d not delete data..try next tym";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            return "Data deleted sucessfully";
        }

        public List<Product> GetAll()
        {
            List < Product > mylist= new List < Product >();
            string conString = "server=localhost; port=3306; username=root; password=pragati; database=dotnet";
            MySqlConnection connection = new MySqlConnection(conString);
            string query = "select * from products";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = int.Parse(reader["product_id"].ToString());
                    string name = reader["name"].ToString();
                    string description = reader["description"].ToString();
                    double price = double.Parse(reader["price"].ToString());
                    int quantity = int.Parse(reader["quantity"].ToString());

                    Product p = new Product();
                    p.Id = id;
                    p.Name = name;
                    p.Description = description;
                    p.price = price;
                    p.quantity = quantity;
                    mylist.Add(p);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }
            finally {
                if (connection.State != System.Data.ConnectionState.Closed) {
                    connection.Close();
                }
            }
            return mylist;
        }

        public Product GetById(int id)
        {
            Product p = new Product();
            string constring = "server=localhost; port=3306; username=root; password=pragati ;database=dotnet";
            MySqlConnection connection = new MySqlConnection(constring);
            string Query = "Select * from products where product_id=@value1";
            try {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@value1", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["name"].ToString();
                    string description = reader["description"].ToString();
                    double price = double.Parse(reader["price"].ToString());
                    int quantity = int.Parse(reader["quantity"].ToString());

                    
                    p.Id = id;
                    p.Name = name;
                    p.Description = description;
                    p.price = price;
                    p.quantity = quantity;
                
                }
                reader.Close();



            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            return p;
        }

        public Product Insert(Product product)
        {
            string conString = "server=localhost; port=3306; username=root; password=pragati; database=dotnet";
            MySqlConnection connection = new MySqlConnection(conString);
            String Query = "insert into products(product_id, name, description, price, quantity) values(@value1, @value2, @value3, @value4, @value5)";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(Query, connection);
                command.Parameters.AddWithValue("@value1", product.Id);
                command.Parameters.AddWithValue("@value2", product.Name);
                command.Parameters.AddWithValue("@value3", product.Description);
                command.Parameters.AddWithValue("@value4", product.price);
                command.Parameters.AddWithValue("@value5", product.quantity);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Insert successful.");
                }
                else
                {
                    Console.WriteLine("Insert failed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            return product;
        }

        public String Update(int id,Product product)
        {
          
            string conString = "server=localhost; port=3306; username=root; password=pragati; database=dotnet";
            MySqlConnection connection = new MySqlConnection(conString);
            String Query = "Update products set name=@value2,description=@value3,price=@value4," +
                "quantity=@value5 where product_id=@value1; ";
            try {
                connection.Open();
                MySqlCommand cmd=new MySqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@value1", id);
                cmd.Parameters.AddWithValue("@value2", product.Name);
                cmd.Parameters.AddWithValue("@value3", product.Description);
                cmd.Parameters.AddWithValue("@value4", product.price);
                cmd.Parameters.AddWithValue("@value5", product.quantity);
                int res = cmd.ExecuteNonQuery();
                if (res<1)
                {
                    return "something went wrong ..update unsucseefull";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            return "DATA Updated";
            

        }
    }
}
