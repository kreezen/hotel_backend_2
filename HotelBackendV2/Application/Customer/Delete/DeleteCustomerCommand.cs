using Domain.Customer;

public class DeleteCustomerCommand : ICommand<Customer>
{
    public Guid Id { get; set; }
}