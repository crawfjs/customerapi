using customerapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace customerapi.Controllers
{
    /// <summary>
    /// Customer API
    /// </summary>
    public class CustomerController : Controller
    {
        // private readonly CustomerDbContext _context;
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Customer API - GET
        /// Retrieves all customers
        /// </summary>
        /// <param name="Page">Page number (0 based)</param>
        /// <param name="PageSize">Page size</param>
        /// <returns>List of customers</returns>
        // GET: api/values
        [Route("api/[controller]")]
        [HttpGet]
        public PagedResponse<Customer> Get([FromQuery] int Page = 0, [FromQuery] int PageSize = 20)
        {
            var totalCount = _customerRepository.CustomerCountAsync();
            var paginatedCustomerData = _customerRepository.GetCustomersAsync(Page, PageSize);

            Task.WaitAll(totalCount, paginatedCustomerData);

            return new PagedResponse<Customer>
            {
                PageNumber = Page,
                PageSize = PageSize,
                TotalPages = (int)Math.Ceiling((double)totalCount.Result / PageSize),
                TotalRecords = totalCount.Result,
                Data = paginatedCustomerData.Result.ToList()
            };
        }

        /// <summary>
        /// Customer API - POST
        /// Adds a new customer
        /// </summary>
        /// <param name="customer"></param>
        [Route("api/[controller]")]
        [HttpPost]
        public async void Post([FromBody] Customer customer)
        {
            await _customerRepository.AddCustomerAsync(customer);
        }

        /// <summary>
        /// Customer API - DELETE
        /// Deletes a customer
        /// </summary>
        /// <param name="id">Customer ID</param>
        [Route("api/[controller]/{id}")]
        [HttpDelete]
        public async void Delete(int id)
        {
            await _customerRepository.DeleteCustomerAsync(id);
        }

        /// <summary>
        /// Customer API - PUT
        /// Updates a customer
        /// </summary>
        /// <param name="customer"></param>
        [Route("api/[controller]")]
        [HttpPut]
        public async void Put([FromBody] Customer customer)
        {
            await _customerRepository.UpdateCustomerAsync(customer);
        }
    }
}

