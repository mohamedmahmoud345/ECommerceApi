using Application.Features.Customers.Queries.GetCustomerByEmail;
using Application.Features.Customers.Queries.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
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

    }
}
