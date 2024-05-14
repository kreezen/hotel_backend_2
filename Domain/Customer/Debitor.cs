namespace Domain.Customer;
using Domain.Invoice;
public class Debitor : Customer
{
    public required string DebitorNumber { get; set; }
    public required List<Invoice> Invoices { get; set; }
}
