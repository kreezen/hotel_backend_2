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

    public async Task<List<Customer>> GetAllCustomersAsync()
    {


        var tasks = await _dbContext.Tasks.Include(x => x.CreatedBy).ToListAsync();

        Console.WriteLine("task:");
        Console.WriteLine(tasks.Count);

        var customers = await _dbContext.Customers
    .Include(t => t.Activities)
    .ToListAsync();

        // Filter Activities as needed (in-memory) afterwards
        foreach (var customer in customers)
        {
            customer.Activities = customer.Activities.Where(x => x.CustomerId == customer.Id).ToList();
        }

        var filteredCustomers = customers.Where(t => t.Activities.Any(x => x.CustomerId == t.Id))
            .ToList(); // Filter based on activity criteria

        Console.WriteLine(filteredCustomers[0].Activities.Count);
        Console.WriteLine(filteredCustomers[0].Activities.Count);

        return filteredCustomers ?? new List<Customer>();
    }

    public async Task<Customer?> GetCustomerByCustomerNumberAsync(string customerNumber)
    {
        return await _dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerNumber == customerNumber);
    }

    public async Task<List<Customer>> GetCustomersBySubstringAsync(string substring)
    {
        return await _dbContext.Customers.Where(x => x.CustomerNumber.Contains(substring)).ToListAsync();
    }
}