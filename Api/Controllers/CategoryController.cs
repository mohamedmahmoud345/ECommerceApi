using Application.Features.Category.Queries.GetAllCategories;
using Application.Features.Category.Queries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());

            return Ok(pagination(categories , pageNumber, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(id));
            if (category == null)
                return NotFound($"Category with ID {id} not found");

            return Ok(category);
        }
        private List<GetAllCategoriesResponse> pagination
            (List<GetAllCategoriesResponse> customers, int? pageNumber, int? pageSize)
        {
            int number = 1;
            if (pageNumber != null)
                number = pageNumber.Value;
            int size = 5;
            if (pageSize != null)
                size = pageSize.Value;

            int count = customers.Count();

            int pagNumbers = (number - 1) * size;
            var custs = customers.Skip(pagNumbers)
                .Take(size)
                .ToList();

            return custs;
        }

    }
}
