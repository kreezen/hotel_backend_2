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
        customer.Customernumber = gId.ToString();
        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync();
        return customer;
    }

    public Task<List<Customer>> GetAllCustomersAsync()
    {
        return _dbContext.Customers.Include(x => x.Activities).Include(x => x.Address).ToListAsync();
    }

    public async Task<Customer?> GetCustomerByCustomerNumberAsync(string customerNumber)
    {
        return await _dbContext.Customers.FirstOrDefaultAsync(x => x.Customernumber == customerNumber);
    }

    public async Task<List<Customer>> GetCustomersBySubstringAsync(string substring)
    {
        return await _dbContext.Customers.Where(x => x.Customernumber.Contains(substring)).ToListAsync();
    }
}