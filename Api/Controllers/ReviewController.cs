using Api.Dto.Review;
using Application.Features.Reviews.Commands.AddReview;
using Application.Features.Reviews.Commands.RemoveReview;
using Application.Features.Reviews.Commands.UpdateReview;
using Application.Features.Reviews.Queries.GetAllReviewsByCustomerId;
using Application.Features.Reviews.Queries.GetAllReviewsByProductId;
using Application.Features.Reviews.Queries.GetReviewById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var review = await _mediator.Send(new GetReviewByIdQuery((id)));

            if (review == null)
                return NotFound($"review with id {id} not found");
            return Ok(review);
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetByProductId(Guid id, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var reviews = await _mediator.Send(new GetAllReviewsByProductIdQuery(id, page, pageSize));

            if (reviews == null)
                return NotFound($"reviews with product id {id} not found");

            return Ok(reviews);
        }

        [HttpGet("customer/{id}")]
        public async Task<IActionResult> GetByCustomerId(Guid id , [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var reviews = await _mediator.Send(new GetAllReviewsByCustomerIdQuery(id , page , pageSize));

            if (reviews == null)
                return NotFound($"reviews with customer id {id} not found");

            return Ok(reviews);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddReviewDto reviewDto)
        {
            var reviewCommand = new AddReviewCommand()
            {
                Comment = reviewDto.Comment,
                Rating = reviewDto.Rating,
                CustomerId = reviewDto.CustomerId,
                ProductId = reviewDto.ProductId
            };

            var result = await _mediator.Send(reviewCommand);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, UpdateReviewDto reviewDto)
        {
            if (id != reviewDto.Id)
                return BadRequest("ID in URL does not match ID in body");

            var review = new UpdateReviewCommand()
            {
                Id = reviewDto.Id,
                Comment = reviewDto.Comment,
                Rating = reviewDto.Rating,
            };

            var result = await _mediator.Send(review);
            if (!result)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new RemoveReviewCommand(id));
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}

