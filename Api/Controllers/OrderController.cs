using Api.Dto.Order;
using Application.Features.Orders.Commands.AddOrder;
using Application.Features.Orders.Commands.CancelOrder;
using Application.Features.Orders.Commands.RefundOrder;
using Application.Features.Orders.Commands.UpdateOrderStatus;
using Application.Features.Orders.Queries.GetAllOrdersByCustomerId;
using Application.Features.Orders.Queries.GetByOrderId;
using MediatR;
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
        [HttpGet("customer/{id:guid}")]
        public async Task<IActionResult> GetAllByCustomerId(Guid id)
        {
            var query = new GetAllOrdersByCustomerIdQuery(id);

            var result = await _mediator.Send(query);
            if (result is null)
                return BadRequest();

            return Ok(result);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var query = new GetByOrderIdQuery(id);

            var result = await _mediator.Send(query);
            if (result is null)
                return BadRequest();

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderDto orderDto)
        {
            var command = new AddOrderCommand(orderDto.CustomerId, orderDto.PaymentMethod);

            var result = await _mediator.Send(command);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> CancelOrder(Guid id)
        {
            var command = new CancelOrderCommand(id);

            var result = await _mediator.Send(command);
            if (result == false)
                return BadRequest();

            return NoContent();
        }

        [HttpPut("status")]
        public async Task<IActionResult> UpdateOrderStatus(UpdateOrderStatusDto statusDto)
        {
            var command = new UpdateOrderStatusCommand(statusDto.OrderId, statusDto.OrderStatus);

            var result = await _mediator.Send(command);
            if (result is false)
                return BadRequest();

            return NoContent();
        }

        [HttpPut("refund/{orderId:guid}")]
        public async Task<IActionResult> RefundOrder(Guid orderId)
        {
            var command = new RefundOrderCommand(orderId);

            var result = await _mediator.Send(command);
            if (result is false)
                return BadRequest();

            return NoContent();
        }
    }
}
