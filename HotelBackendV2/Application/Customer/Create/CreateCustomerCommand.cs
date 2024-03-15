
using Domain.Customer;

public class CreateCustomerCommand : ICommand<Customer>
{
    public required CustomerType CustomerType { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required Address Address { get; set; }

}