
using Domain.Activities;
namespace Domain.Invoice;
public class Invoice
{
    public Guid Id { get; set; }
    public DateTime InvoiceDate { get; set; }
    public DateTime CreatedOn { get; set; }
    public required string InvoiceNumber { get; set; }
    public required List<Activity> Activities { get; set; }
}

