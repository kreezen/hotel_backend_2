
using Domain.Customer;
using SharedKernel;

public class GetAllCustomersHandler : IQueryHandler<GetAllCustomersQuery, List<Customer>>
{
    private readonly ICustomerRepository _customerRepository;
    public GetAllCustomersHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result<List<Customer>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetAllCustomersAsync();
        return customers;
    }
}