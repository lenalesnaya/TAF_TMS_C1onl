using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Services.DataBases;

namespace TAF_TMS_C1onl.Tests.DataBase
{
    internal class SimpleDataBaseTest
    {
        private SimpleDBConnector _simpleDBConnector;
        private CustomersService _customersService;

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
    }
}