using Domain.Customer;

public class SearchByCustomerQuery : IQuery<List<Customer>>
{
    public required string SearchString { get; set; }
}