using Microsoft.AspNetCore.Mvc;
using MyApiProject.Services;
using MyApiProject.Models;
using MyApiProject.Dtos;
using AutoMapper;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
        {
            var customers = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customers));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetById(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> Create(CreateCustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);
            var created = await _service.CreateAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<CustomerDto>(created));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var customer = _mapper.Map<Customer>(dto);
            await _service.UpdateAsync(customer);
            return Ok("Customer updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return Ok("Customer deleted");
        }
        [HttpGet("with-product")]
        public async Task<ActionResult<IEnumerable<object>>> GetCustomersWithProduct()
        {
            var customers = await _service.GetAllAsync();
            var result = customers.Select(c => new {
                CustomerName = c.Name,
                ProductName = c.Product?.Name,
                ProductPrice = c.Product?.Price
            });

            return Ok(result);
        }
    }
}
