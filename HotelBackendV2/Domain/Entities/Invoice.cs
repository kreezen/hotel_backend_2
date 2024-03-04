using System.Collections;

public record Invoice(
    Guid Id,
    DateTime InvoiceDate,
    DateTime CreatedOn,
    string InvoiceNumber,
    Activity[] Activities
);