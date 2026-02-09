using Api.Dto.Cart;
using Application.Features.Cart.Commands.AddItemToCart;
using Application.Features.Cart.Commands.ClearCart;
using Application.Features.Cart.Commands.DeleteItemFromCart;
using Application.Features.Cart.Commands.UpdateItemQuantity;
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
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteItemDto deleteItem)
        {
            var command = new DeleteItemFromCartCommand(
                deleteItem.CustomerId,
                deleteItem.ItemId
            );
            var success = await _mediator.Send(command);
            if (!success)
                return BadRequest();

            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateItemQuantityDto item)
        {
            var command = new UpdateItemQuantityCommand(item.CustomerId, item.ItemId, item.quantity);
            var success = await _mediator.Send(command);

            if (!success)
                return BadRequest();

            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> ClearCart(Guid id)
        {
            var command = new ClearCartCommand(id);

            var success = await _mediator.Send(command);
            if (!success)
                return BadRequest();

            return NoContent();
        }
    }
}
