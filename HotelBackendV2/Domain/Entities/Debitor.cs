namespace Domain.Entities;
public class Debitor : Customer
{
    public required string DebitorNumber { get; set; }
    public required Invoice[] Invoices { get; set; }
}
