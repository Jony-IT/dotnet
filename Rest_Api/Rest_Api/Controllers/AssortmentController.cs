using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rest_Api.Models;

namespace Rest_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssortmentController : Controller
    {
        private OrdersContext _context;

        public AssortmentController(OrdersContext _context)
        { 
            this._context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersRegistration>>> GetAllAssortment()
        {
            var assortment = await _context.Products.ToListAsync();
            return Ok(assortment);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersRegistration>> GetProduct(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrdersRegistration order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return Ok(order);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrdersRegistration order)
        {
            OrdersRegistration? p = await _context.Orders.FindAsync(order.Id);
            if (p == null) return NotFound();
            p.ProductCode = order.ProductCode;
            p.ProductName = order.ProductName;
            p.OrderDate = order.OrderDate;
            p.OrderCost = order.OrderCost;
            p.Customer = order.Customer;
            _context.Update(p);
            await _context.SaveChangesAsync();
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
}
}
