using Api.Dto.Category;
using Application.Features.Categories.Commands.AddCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Queries.GetAllCategories;
using Application.Features.Categories.Queries.GetCategoryById;
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

            return Ok(pagination(categories, pageNumber, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(id));
            if (category == null)
                return NotFound($"Category with ID {id} not found");

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryDto categoryDto)
        {
            var categoryCommand = new AddCategoryCommand()
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };
            var category = await _mediator.Send(categoryCommand);

            return CreatedAtAction(nameof(GetById), new { Id = category.Id }, category);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, UpdateCategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
                return BadRequest("ID in URL does not match ID in body");
            var categorCommand = new UpdateCategoryCommand()
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };

            var result = await _mediator.Send(categorCommand);
            if (!result)
                return BadRequest(categorCommand);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id));

            if (!result)
                return BadRequest();

            return NoContent();
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
