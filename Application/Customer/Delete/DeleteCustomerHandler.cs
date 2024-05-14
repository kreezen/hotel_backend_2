
using Domain.Customer;
using SharedKernel;

public class DeleteCustomerHandler : ICommandHandler<DeleteCustomerCommand, Customer>
{
    private readonly ICustomerRepository _customerRepository;
    public DeleteCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result<Customer>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(request.Id);

        if (customer == null)
        {
            return Result.Failure<Customer>(Error.NotFound("Customer.NotFound", "Customer not found"));
        }

        await _customerRepository.DeleteCustomerAsync(request.Id);
        return customer;
    }
}