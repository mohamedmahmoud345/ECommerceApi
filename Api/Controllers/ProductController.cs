using Api.Dto.Product;
using Application.Features.Products.Commands.AddProduct;
using Application.Features.Products.Commands.DeleteProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Commands.UpdateProductImage;
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.Products.Queries.GetProductById;
using Application.Features.Products.Queries.GetProductsByCategoryId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _environment;
        public ProductController(IMediator mediator, IWebHostEnvironment environment)
        {
            _mediator = mediator;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var products = await _mediator.Send(new GetAllProductsQuery(page, pageSize));

            if (products == null)
                return BadRequest();

            return Ok(products);

        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            if (product == null)
                return NotFound($"Product with ID {id} not found");
            return Ok(product);
        }

        [HttpGet("category/{id:guid}")]
        public async Task<IActionResult> GetByCategoryId(Guid id, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var products = await _mediator.Send(new GetProductsByCategoryIdQuery(id, page, pageSize));
            if (products == null)
                return NotFound($"Category with id {id} not found");

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AddProductDto productDto)
        {
            var command = new AddProductCommand()
            {
                Name = productDto.Name,
                CategoryId = productDto.CategoryId,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
                ImageName = productDto.ImageUrl.FileName,
                ImageStream = productDto.ImageUrl.OpenReadStream()
            };
            var success = await _mediator.Send(command);
            if (success == null)
                return BadRequest($"Invalid category id {productDto.CategoryId}");

            return CreatedAtAction(nameof(GetById), new { Id = success.Id }, success);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Edit(Guid id, UpdateProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != productDto.Id)
                return BadRequest("ID in URL does not match ID in body");

            var productCommand = new UpdateProductCommand
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description,
                CategoryId = productDto.CategoryId,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
            };

            var success = await _mediator.Send(productCommand);
            if (!success)
                return BadRequest();

            return NoContent();
        }
        [HttpPut("image/{id}")]
        public async Task<IActionResult> EditImage(Guid id, IFormFile image)
        {
            var command = new UpdateProductImageCommand()
            {
                Id = id,
                ImageName = image.FileName,
                ImageStream = image.OpenReadStream()
            };

            var success = await _mediator.Send(command);
            if (!success)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _mediator.Send(new DeleteProductCommand(id));

            if (!success)
                return BadRequest($"customer with id {id} not found");

            return NoContent();
        }
    }
}
