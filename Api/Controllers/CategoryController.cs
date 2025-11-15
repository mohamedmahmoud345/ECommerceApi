using Application.Features.Category.Queries.GetAllCategories;
using Application.Features.Customers.Queries.GetAllCustomers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
