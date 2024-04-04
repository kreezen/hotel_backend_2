using Domain.Customer;
using Domain.Activities;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Activities.Task;

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

    public async Task<List<Customer>> GetAllCustomersAsync()
    {

        var customers = await _dbContext.Customers
        .Include(t => t.Activities)
        .Include(t => t.Address)
        .ToListAsync(); // Fetch data

        // Then fetch CreatedBy for specific types:
        foreach (var customer in customers)
        {
            // For Tasks 
            _dbContext.Entry(customer).Collection(c => c.Activities).Query()
                      .OfType<Task>()
                      .Include(t => t.ModifiedBy)
                      .Load();

            // For Emails
            _dbContext.Entry(customer).Collection(c => c.Activities).Query()
                      .OfType<Email>()
                      .Include(e => e.CreatedBy)
                      .Load();
        }

        return customers;
    }

    public async Task<Customer?> GetCustomerByCustomerNumberAsync(string customerNumber)
    {
        return await _dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerNumber == customerNumber);
    }

    public async Task<List<Customer>> GetCustomersBySubstringAsync(string substring)
    {
        return await _dbContext.Customers.Where(x => x.LastName.ToLower().Contains(substring.ToLower())).ToListAsync();
    }
}