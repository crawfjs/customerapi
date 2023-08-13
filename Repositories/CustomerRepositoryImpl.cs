using customerapi.DataModel;
using Microsoft.EntityFrameworkCore;

namespace customerapi.Repositories
{
    public class CustomerRepositoryImpl : ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepositoryImpl(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                transaction.Commit();
            }
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            Console.WriteLine($"Deleting customer {customerId}");
            using (var transaction = _context.Database.BeginTransaction())
            {
                _context.Customers
                    .Where(c => c.Id == customerId)
                    .ExecuteDelete();
                await _context.SaveChangesAsync();
                transaction.Commit();
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync(int Page = 0, int PageSize = 20)
        {
            return await _context.Customers
                .OrderBy(b => b.LastName).ThenBy(b => b.FirstName)
                .Skip(Page * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }

        public async Task<int> CustomerCountAsync()
        {
            return await _context.Customers.CountAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                _context.Customers.Where(c => c.Id == customer.Id).ExecuteUpdate(c =>

                    c.SetProperty(x => x.FirstName, customer.FirstName)
                     .SetProperty(x => x.LastName, customer.LastName)
                );
                await _context.SaveChangesAsync();
                transaction.Commit();
            }
        }
    }
}