using DDD_Investigation.Domain.BuyerAggregate;
using DDD_Investigation.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace DDD_Investigation.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly DDDContext _context;

        public CustomersController(DDDContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCustomer([FromBody] string name)
        {
            var customer = new Customer(name);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(string name,int customerId)
        {

            var customer = await _context.Customers.FindAsync(customerId);
            customer.SetName(name);
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }
    }
}
