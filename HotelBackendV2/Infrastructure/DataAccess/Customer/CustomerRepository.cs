using Domain.Customer;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : ICustomerRepository
{
    private readonly HotelDbContext _dbContext;
    CustomerRepository(HotelDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync();
        return customer;
    }

    public Task<List<Customer>> GetAllCustomersAsync()
    {
        return _dbContext.Customers.ToListAsync();
    }

    public Task<Customer?> GetCustomerByCustomerNumberAsync(string customerNumber)
    {
        return _dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerNumber == customerNumber);
    }
}