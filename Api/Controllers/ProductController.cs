using Application.Features.Customers.Queries.GetAllCustomers;
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.Products.Queries.GetProductById;
using Application.Features.Products.Queries.GetProductsByCategoryId;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? pageNumber , [FromQuery] int? pageSize)
        {
            var products =await _mediator.Send(new GetAllProductsQuery());
            return Ok(pagination(products, pageNumber, pageSize));

        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            if (product == null)
                return NotFound($"Product with ID {id} not found");
            return Ok(product);
        }

        [HttpGet("category/{id:guid}")]
        public async Task<IActionResult> GetByCategoryId(Guid id , int? pageNumber , int? pageSize)
        {
            var products = await _mediator.Send(new GetProductsByCategoryIdQuery(id));
            if (products == null)
                return NotFound($"Category with id {id} not found");

            return Ok(pagination(products, pageNumber, pageSize));
        }



        private List<T> pagination<T>
            (List<T> products, int? pageNumber, int? pageSize) where T : class
        {
            int number = 1;
            if (pageNumber != null)
                number = pageNumber.Value;
            int size = 5;
            if (pageSize != null)
                size = pageSize.Value;

            int count = products.Count();

            int pagNumbers = (number - 1) * size;
            var custs = products.Skip(pagNumbers)
                .Take(size)
                .ToList();

            return custs;
        }
        
    }
}
