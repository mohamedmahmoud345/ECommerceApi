using Api.Dto.Order;
using Application.Features.Cart.Queries.GetAllCartItemsByCustomerId;
using Application.Features.Orders.Commands.AddOrder;
using Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAllByCustomerId(Guid id)
        {
            var query = new GetAllCartItemsByCustomerIdQuery(id);

            var result = await _mediator.Send(query);
            if (result is null)
                return BadRequest();

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderDto orderDto)
        {
            var command = new AddOrderCommand(orderDto.CustomerId);

            var result = await _mediator.Send(command);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }
    }
}
