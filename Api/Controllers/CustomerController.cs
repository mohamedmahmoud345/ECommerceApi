using Api.Dto.Customer;
using Application.Features.Customers.Commands.AddCustomer;
using Application.Features.Customers.Commands.DeleteCustomer;
using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Features.Customers.Queries.GetAllCustomers;
using Application.Features.Customers.Queries.GetCustomerByEmail;
using Application.Features.Customers.Queries.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var customers = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(pagination(customers, pageNumber, pageSize));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
            if (customer == null)
                return NotFound($"Customer with ID {id} not found");
            return Ok(customer);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetByEmail([EmailAddress] string email)
        {
            var customer = await _mediator.Send(new GetCustomerByEmailQuery(email));
            if (customer == null)
                return NotFound($"Customer with email {email} not found");

            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customerCommand = new AddCustomerCommand()
            {
                Name = customerDto.Name,
                Address = customerDto.Address,
                Email = customerDto.Email,
                Phone = customerDto.Phone,
            };
            var customer = await _mediator.Send(customerCommand);

            if (customer == null)
                return BadRequest("Email already exists");

            return CreatedAtAction(nameof(GetById), new { Id = customer.Id }, customer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteCustomerCommand(id));

            if (result != true)
                return NotFound($"customer with id {id} not found");

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] UpdateCustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != customerDto.Id)
                return BadRequest("ID in URL does not match ID in body");

            var customerCommand = new UpdateCustomerCommand
            {
                Id = customerDto.Id,
                Name = customerDto.Name,
                Address = customerDto.Address,
                Email = customerDto.Email,
                Phone = customerDto.Phone
            };

            var success = await _mediator.Send(customerCommand);

            if (!success)
                return NotFound($"Customer with ID {customerDto.Id} not found");
            return NoContent();
        }

        private List<GetAllCustomersResponse> pagination
            (List<GetAllCustomersResponse> customers, int? pageNumber, int? pageSize)
        {
            int number = 1;
            if (pageNumber != null)
                number = pageNumber.Value;
            int size = 5;
            if (pageSize != null)
                size = pageSize.Value;

            int count = customers.Count();

            int pagNumbers = (number - 1) * size;
            var custs = customers.Skip(pagNumbers)
                .Take(size)
                .ToList();

            return custs;
        }
    }
}
