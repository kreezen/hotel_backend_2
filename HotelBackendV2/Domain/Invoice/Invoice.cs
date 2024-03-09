using System.Collections;
namespace Domain.Invoice;
public record Invoice(
    Guid Id,
    DateTime InvoiceDate,
    DateTime CreatedOn,
    string InvoiceNumber,
    Activity[] Activities
);