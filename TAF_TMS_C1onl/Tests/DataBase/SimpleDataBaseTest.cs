using NLog;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Services.DataBases;

namespace TAF_TMS_C1onl.Tests.DataBase
{
    internal class SimpleDataBaseTest
    {
        private SimpleDBConnector _simpleDBConnector;
        private CustomersService _customersService;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _simpleDBConnector = new SimpleDBConnector();
            _customersService = new CustomersService(_simpleDBConnector.Connection);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _simpleDBConnector.CloseConnection();
        }

        [Test]
        public void Tmp()
        {
            _customersService.DropTable();
            _customersService.CreateTable();
        }

        [Test]
        public void GetAllCustomersTest()
        {
            var customersList = _customersService.GetAllCustomers();

            Assert.That(customersList.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddCustomerTest()
        {
            _logger.Info("Add customer test started");

            var affectedRows= _customersService.AddCustomer(new Customer
            {
                FirstName = "Lena",
                LastName = "Lesnaya",
                Email = "email@email.ru",
                Age = 150
            });

            Assert.That(affectedRows, Is.EqualTo(1));
            _logger.Info("Add customer test ended");
        }

        [Test]
        public void DeleteCustomerTest()
        {
            _logger.Info("Delete customer test started");

            var affectedRows = _customersService.DeleteCustomer("Lena", "Lesnaya");

            Assert.That(affectedRows, Is.EqualTo(1));
            _logger.Info("Delete customer test ended");
        }
    }
}