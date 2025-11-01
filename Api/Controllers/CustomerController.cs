using Api.Dto.CustomerDto;
using Application.Features.Customers.Commands.AddCustomer;
using Application.Features.Customers.Commands.DeleteCustomer;
using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Features.Customers.Queries.GetAllCustomers;
using Application.Features.Customers.Queries.GetCustomerByEmail;
using Application.Features.Customers.Queries.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Get()
        {
            var customers = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetByEmail([EmailAddress] string email)
        {
            var customer = await _mediator.Send(new GetCustomerByEmailQuery(email));
            if (customer == null)
                return NotFound();

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
                return BadRequest();

            return CreatedAtAction(nameof(GetById) , new {Id = customer.Id} , customer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result =  await _mediator.Send(new DeleteCustomerCommand(id));

            if(result != true)
                return BadRequest();

            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Edit(UpdateCustomerDto customerDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            
            var customerCommand = new UpdateCustomerCommand
            {
                Id = customerDto.Id,
                Name = customerDto.Name,
                Address = customerDto.Address,
                Email = customerDto.Email,
                Phone = customerDto.Phone
            };

            await _mediator.Send(customerCommand);

            return RedirectToAction(nameof(GetById), new { Id = customerDto.Id });
        }
    }
}
