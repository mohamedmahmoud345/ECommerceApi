using Api.Dto.Customer;
using Application.Features.Customers.Commands.DeleteCustomer;
using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Features.Customers.Queries.GetAllCustomers;
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
        public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var customers = await _mediator.Send(new GetAllCustomersQuery(page, pageSize));
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
            if (customer == null)
                return NotFound($"Customer with ID {id} not found");
            return Ok(customer);
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
                Phone = customerDto.Phone
            };

            var success = await _mediator.Send(customerCommand);

            if (!success)
                return NotFound($"Customer with ID {customerDto.Id} not found");
            return NoContent();
        }
    }
}
