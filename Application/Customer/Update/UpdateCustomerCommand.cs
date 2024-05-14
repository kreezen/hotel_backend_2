using Domain.Customer;

public class UpdateCustomerCommand : ICommand<Customer>
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required Address Address { get; set; }
    public required CustomerType CustomerType { get; set; }
}