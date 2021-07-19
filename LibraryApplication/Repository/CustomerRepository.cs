using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using LibraryApplication.Models;
namespace LibraryApplication.Repository
{
    public class CustomerRepository
    {
        private SqlConnection connection;
        private void createConnection()
        {
            connection = new SqlConnection("data source=.;database=CustomerDB;integrated security=true");
        }

        //To add customer
        public bool addCustomer(Customer customer)
        {
            createConnection();
            string query = "INSERT INTO Customer VALUES(@Id,@Name,@City,@Address)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", customer.CustomerID);
            cmd.Parameters.AddWithValue("@Name", customer.CustomerName);
            cmd.Parameters.AddWithValue("@City", customer.City);
            cmd.Parameters.AddWithValue("@Address", customer.Address);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //To get All Customers
        public List<Customer> getAllCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            createConnection();
            string query = "SELECT * FROM Customer";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Customer customer = new Customer();
                customer.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                customer.CustomerName = Convert.ToString(reader["Name"]);
                customer.City = Convert.ToString(reader["City"]);
                customer.Address = Convert.ToString(reader["Address"]);
                customerList.Add(customer);
            }
            connection.Close();
            return customerList;
        }

        //To update customer
        public bool updateCustomer(Customer customer)
        {
            createConnection();
            string query = "UPDATE Customer SET CustomerID = @Id ,Name = @Name, City=@City, Address =@address WHERE CustomerID = @Id2";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", customer.CustomerID);
            cmd.Parameters.AddWithValue("@Name", customer.CustomerName);
            cmd.Parameters.AddWithValue("@City", customer.City);
            cmd.Parameters.AddWithValue("@address", customer.Address);
            cmd.Parameters.AddWithValue("@Id2", customer.CustomerID);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //To Delete Customer

        public bool deleteCustomer(int id)
        {
            createConnection();
            string query = "DELETE FROM Customer WHERE CustomerID = @Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", id);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}