using Domain.Customer;
using SharedKernel;

public class UpdateCustomerHandler : ICommandHandler<UpdateCustomerCommand, Customer>
{
    private readonly ICustomerRepository _customerRepository;
    public UpdateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result<Customer>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(request.Id);
        if (customer == null)
        {
            return Result.Failure<Customer>(Error.NotFound("Customer.NotFound", "Customer not found"));
        }

        customer.Email = request.Email;
        customer.FirstName = request.FirstName;
        customer.LastName = request.LastName;
        customer.Address = request.Address;
        customer.CustomerType = request.CustomerType;

        await _customerRepository.SaveChangesAsync();
        return customer;
    }
}