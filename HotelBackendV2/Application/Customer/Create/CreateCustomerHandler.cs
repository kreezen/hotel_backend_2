
using Domain.Activities;
using Domain.Customer;
using SharedKernel;

public class CreateCustomerHandler : ICommandHandler<CreateCustomerCommand, Customer>
{
    private readonly ICustomerRepository _customerRepository;


    public CreateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;

    }

    public async Task<Result<Customer>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            Email = request.Email,
            Id = Guid.NewGuid(),
            CustomerNumber = Guid.NewGuid().ToString(),
            Activities = new List<Activity>(),
            CustomerType = request.CustomerType,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Address = request.Address
        };

        return await _customerRepository.CreateCustomerAsync(customer);

    }

}