using Api.Dto.Cart;
using Application.Features.Cart.Commands.AddItemToCart;
using Application.Features.Cart.Queries.GetAllCartItemsByCustomerId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByCustomerId(Guid id)
        {
            var items = await _mediator.Send(new GetAllCartItemsByCustomerIdQuery(id));
            if (items == null)
                return BadRequest();

            return Ok(items);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddItemDto itemDto)
        {
            var command = new AddItemToCartCommand()
            {
                CustomerId = itemDto.CustomerId,
                ProductId = itemDto.ProductId,
                Quantity = itemDto.Quantity
            };

            var result = await _mediator.Send(command);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }
    }
}
