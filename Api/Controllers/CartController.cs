using Api.Dto.Cart;
using Application.Features.Cart.Commands.AddItemToCart;
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

        [HttpPost]
        public async Task<IActionResult> Add(AddItemDto itemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
