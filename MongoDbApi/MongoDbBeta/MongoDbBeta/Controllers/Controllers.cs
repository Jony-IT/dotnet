using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDbBeta.Models;
using MongoDbBeta.Services;

namespace MongoDbBeta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssortmentController : ControllerBase
    {
        private readonly AssortmentService _service;

        public AssortmentController(AssortmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Assortment>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Assortment>> GetById(string id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Assortment item)
        {
            await _service.CreateAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Assortment item)
        {
            var exist = await _service.GetByIdAsync(id);
            if (exist == null) return NotFound();

            item.Id = id;
            await _service.UpdateAsync(id, item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var exist = await _service.GetByIdAsync(id);
            if (exist == null) return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _service;

        public OrderController(OrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(string id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpGet("by-date/{date}")]
        public async Task<IEnumerable<Order>> GetByDate(DateTime date) =>
            await _service.GetByOrderDateAsync(date);

        [HttpPost]
        public async Task<IActionResult> Create(Order item)
        {
            await _service.CreateAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Order item)
        {
            var exist = await _service.GetByIdAsync(id);
            if (exist == null) return NotFound();

            item.Id = id;
            await _service.UpdateAsync(id, item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var exist = await _service.GetByIdAsync(id);
            if (exist == null) return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
