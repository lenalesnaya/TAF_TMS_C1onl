using NLog;
using System.Data.Common;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.Tests.DataBase
{
    internal class EFDBTest
    {
        private EFDBConnector _efDbConnector;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _efDbConnector = new EFDBConnector();
        }

        [Test]
        public void SelectTest()
        {
            _logger.Info("Start EFDBTest");

            using (var dbConnector = _efDbConnector)
            {
                var customer1 = new Customer
                {
                    FirstName = "Sasha",
                    LastName = "Koryavyj",
                    Email = "mail@mail.com",
                    Age = 98
                };

                var customer2 = new Customer
                {
                    FirstName = "Irisha",
                    LastName = "Ozyornaya",
                    Age = 10
                };

                var entityCustomer1 = dbConnector.Customers!.Add(customer1);
                var entityCustomer2 = dbConnector.Customers!.Add(customer2);

                dbConnector.SaveChanges();
                _logger.Info(entityCustomer1.ToString() + " " + entityCustomer2);

                _logger.Info("First name " + entityCustomer1.Entity.FirstName);
                dbConnector.Customers.Find(entityCustomer1.Entity.Id);

                var customers = dbConnector.Customers.ToList();
                foreach (var customer in customers)
                {
                    _logger.Info($"{customer.FirstName} {customer.LastName}");
                    dbConnector.Customers.Remove(customer);
                }

                dbConnector.SaveChanges();
            }
        }
    }
}