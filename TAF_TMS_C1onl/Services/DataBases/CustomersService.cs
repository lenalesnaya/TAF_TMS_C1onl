using NLog;
using Npgsql;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.Services.DataBases
{
    internal class CustomersService
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly NpgsqlConnection _connection;

        public CustomersService(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public void CreateTable()
        {
            var query = "CREATE TABLE customers (" +
                                "id SERIAL PRIMARY KEY, " +
                                "firstname CHARACTER VARYING(30), " +
                                "lastname CHARACTER VARYING(30), " +
                                "email CHARACTER VARYING(30), " +
                                "age INTEGER" +
                                ");";

            using var cmd = new NpgsqlCommand(query, _connection);
            cmd.ExecuteNonQuery();
        }

        public void DropTable()
        {
            var query = "drop table if exists customers";

            using var cmd = new NpgsqlCommand(query, _connection);
            cmd.ExecuteNonQuery();
        }

        public List<Customer> GetAllCustomers()
        {
            var query = "SELECT * FROM customers";
            var customersList = new List<Customer>();

            using var cmd = new NpgsqlCommand(query, _connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var customer = new Customer()
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(reader.GetOrdinal("firstname")),
                    LastName = reader.GetString(reader.GetOrdinal("lastname")),
                    Email = reader.GetString(3),
                    Age = reader.GetInt32(reader.GetOrdinal("age"))
                };

                _logger.Info(customer.ToString);
                customersList.Add(customer);
            }

            return customersList;
        }

        public void AddCustomer(Customer customer)
        {

        }

        public void DeleteCustomer(Customer customer)
        {

        }
    }
}