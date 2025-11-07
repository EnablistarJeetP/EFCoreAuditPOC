using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<CustomerEntity>> GetCustomers();

        public Task<CustomerEntity> GetCustomerDetailsById(int id);

        public Task<CustomerEntity> CreateCustomer(CustomerEntity product);

        public Task<bool> DeleteCustomer(int id);

        public Task<bool> UpdateCustomerData(int Id, CustomerEntity product);
    }
}
