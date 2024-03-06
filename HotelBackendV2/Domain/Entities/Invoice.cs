using System.Collections;
namespace Domain.Entities;
public record Invoice(
    Guid Id,
    DateTime InvoiceDate,
    DateTime CreatedOn,
    string InvoiceNumber,
    Activity[] Activities
);