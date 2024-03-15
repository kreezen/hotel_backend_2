namespace Domain.Customer;
using Domain.Invoice;
public class Debitor : Customer
{
    public required string DebitorNumber { get; set; }
    public required Invoice[] Invoices { get; set; }
}
