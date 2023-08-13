namespace customerapi.Repositories
{
    /// <summary>
    /// Customer Repository Interface
    /// Intended to define the interaction between the caller and the repository layer
    /// </summary>
    public interface ICustomerRepository
    {
        Task AddCustomerAsync(Customer customer);

        Task DeleteCustomerAsync(int customerId);

        Task<IEnumerable<Customer>> GetCustomersAsync(int Page = 0, int PageSize = 20);

        Task<int> CustomerCountAsync();

        Task UpdateCustomerAsync(Customer customer);
    }
}