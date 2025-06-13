using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rest_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersContext _context;

        public OrdersController(OrdersContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersRegistration>>> GetAllOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }

          [HttpGet("report/{date}")]
        public async Task<ActionResult<IEnumerable<OrdersRegistration>>> GetOrdersReport(DateTime date)
        {
            var orders = await _context.Orders
                .Where(o => o.OrderDate.Date == date.Date)
                .ToListAsync();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersRegistration>> GetOrder(int id)
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
