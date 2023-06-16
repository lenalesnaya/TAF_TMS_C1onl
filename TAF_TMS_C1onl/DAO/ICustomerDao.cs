using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.DAO
{
    public interface ICustomerDao
    {
        List<Customer> GetAllCustomers();

        Customer? GetById(int id);

        int Add(Customer customer);

        int Update(Customer customer);

        int Delete(int id);
    }
}