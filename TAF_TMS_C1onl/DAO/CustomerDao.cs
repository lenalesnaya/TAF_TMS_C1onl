using NLog;
using Npgsql;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.DAO
{
    internal class CustomerDao : ICustomerDao
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly NpgsqlConnection _connection;

        public CustomerDao(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public int Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
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

        public Customer? GetById(int id)
        {
            var query = "SELECT * FROM customers WHERE id = @id";

            using (var cmd = new NpgsqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Customer()
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(reader.GetOrdinal("firstname")),
                            LastName = reader.GetString(reader.GetOrdinal("lastname")),
                            Email = reader.GetString(3),
                            Age = reader.GetInt32(reader.GetOrdinal("age"))
                        };
                    }
                }
            }

            return null;
        }

        public int Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}