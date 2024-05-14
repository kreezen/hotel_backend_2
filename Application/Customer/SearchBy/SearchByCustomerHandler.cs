
using Domain.Customer;
using SharedKernel;

public class SearchByCustomerHandler : IQueryHandler<SearchByCustomerQuery, List<Customer>>
{
    private readonly ICustomerRepository _customerRepository;
    public SearchByCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<Result<List<Customer>>> Handle(SearchByCustomerQuery request, CancellationToken cancellationToken)
    {
        var searchString = request.SearchString.ToLower();
        return await _customerRepository.GetCustomersBySubstringAsync(searchString);
    }
}