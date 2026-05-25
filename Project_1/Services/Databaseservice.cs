using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Project_1.Models;

namespace Project_1.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString = config.GetConnectionString("DefaultConnection")!;
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Customers";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                CustomerName = reader["CustomerName"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                City = reader["City"].ToString(),
                                LoanStatus = reader["LoanStatus"].ToString(),
                                CallsToday = Convert.ToInt32(reader["CallsToday"]),
                                LastCallDate = Convert.ToDateTime(reader["LastCallDate"])
                            });
                        }
                    }
                }
            }

            return customers;
        }
    }
}