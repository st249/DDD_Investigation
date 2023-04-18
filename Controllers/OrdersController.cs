using DDD_Investigation.Domain.BuyerAggregate;
using DDD_Investigation.Domain.OrderAggregate;
using DDD_Investigation.Domain.PublicationAggregate;
using DDD_Investigation.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DDD_Investigation.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly DDDContext _context;

        public OrdersController(DDDContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewOrder([FromBody] string name, int customerId, string productName, decimal price)
        {
            var customer = new Customer("AAA");
            _context.Customers.Add(customer);
            var order = new VirtualOrder(name, customer.Id);
            var inPersonOrder = new InPersonOrder(name, customer.Id);
            order.AddOrderItem(productName, new Price("IRR", price));
            inPersonOrder.AddOrderItem("InPersonOrder", new Price("SSS", 100));
            inPersonOrder.SetCode(200);
            order.SetPostCost(8000);
            _context.Orders.Add(order);
            _context.Orders.Add(inPersonOrder);
            await _context.SaveChangesAsync();
            return Ok(order);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .SingleAsync(o => o.Id == orderId);
            if (order is InPersonOrder inpersonOrder)
            {
                inpersonOrder.SetCode(555);
            }
            await _context.SaveChangesAsync();
            return Ok(order);
        }

        [HttpPost("CreatePub")]
        public async Task<IActionResult> CreateNewPublication()
        {
            var book = new Book("Book", "Book-Publisher", "Book-Author");
            book.VersionNumber = 1;

            var eBook = new EBook("Book", "Book-Publisher", "Book-Author");
            eBook.Format = "EPUB";

            _context.Publications.Add(book);
            _context.Publications.Add(eBook);

            await _context.SaveChangesAsync();
            return Ok(new { book = book, eBook = eBook });
        }

        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook(int bookId)
        {
            var book = await _context.Publications.SingleAsync(e => e.Id == bookId);

            if (book is Book entity)
                entity.VersionNumber = 1;
            else throw new Exception();

            await _context.SaveChangesAsync();
            return Ok(new { xbook = book });
        }
    }
}
