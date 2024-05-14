using Domain.Customer;

public interface ICustomerRepository
{
    Task<Customer> CreateCustomerAsync(Customer customer);
    Task<Customer?> GetCustomerByCustomerNumberAsync(string customerNumber);
    Task<List<Customer>> GetAllCustomersAsync();
    Task<List<Customer>> GetCustomersBySubstringAsync(string substring);
    Task<Customer?> GetCustomerByIdAsync(Guid id);
    Task<int> SaveChangesAsync();
    Task<int> DeleteCustomerAsync(Guid id);
}
