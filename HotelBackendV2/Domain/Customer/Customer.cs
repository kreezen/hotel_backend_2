
using Domain.Activities;

namespace Domain.Customer;
public class Customer
{


    public Guid Id { get; set; }
    public required Activity[] Activities { get; set; }
    public required string CustomerNumber { get; set; }
    public CustomerType CustomerType { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required Address Address { get; set; }
}
