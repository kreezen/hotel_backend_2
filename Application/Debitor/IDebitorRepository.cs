using Domain.Customer;

public interface IDebitorRepository
{
    Task<Debitor> CreateDebitorAsync(Debitor debitor);
    Task<Debitor> GetByCustomerNumberAsync(string customerNumber);
    Task<Debitor> GetAllDebitorsAsync();

}