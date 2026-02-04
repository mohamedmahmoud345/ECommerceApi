using Api.Dto.Payment;
using Application.Features.Orders.Queries.GetByOrderId;
using Application.Features.Payments.Commands.ProcessPayment;
using Application.Features.Payments.Commands.UpdatePaymentStatus;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment(ProcessPaymentDto paymentDto)
        {

            var command =
             new ProcessPaymentCommand(paymentDto.OrderId, paymentDto.PaymentMethod);

            var result = await _mediator.Send(command);
            if (result is null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePaymentStatus(UpdatePaymentStatusDto statusDto)
        {
            var command = new UpdatePaymentStatusCommand(statusDto.id, statusDto.PaymentStatus);

            var result = await _mediator.Send(command);
            if (result == false)
                return BadRequest();

            return NoContent();
        }

        [HttpGet("{orderId:guid}")]
        public async Task<IActionResult> GetByOrderId(Guid orderId)
        {
            var command = new GetByOrderIdQuery(orderId);

            var result = await _mediator.Send(command);
            if (result is null)
                return BadRequest();

            return Ok(result);
        }
    }
}
