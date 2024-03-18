using Domain.Customer;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : ICustomerRepository
{
    private readonly HotelDbContext _dbContext;
    public CustomerRepository(HotelDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        var gId = Guid.NewGuid();
        customer.Id = gId;
        customer.CustomerNumber = gId.ToString();
        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync();
        return customer;
    }

    public Task<List<Customer>> GetAllCustomersAsync()
    {
        return _dbContext.Customers.Include(x => x.Activities).Include(x => x.Address).ToListAsync();
    }

    public Task<Customer?> GetCustomerByCustomerNumberAsync(string customerNumber)
    {
        return _dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerNumber == customerNumber);
    }
}