using Api.Dto.Product;
using Application.Features.Products.Commands.AddProduct;
using Application.Features.Products.Commands.DeleteProduct;
using Application.Features.Products.Commands.UpdateProduct;
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
        public async Task<IActionResult> Get([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(pagination(products, pageNumber, pageSize));

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
        public async Task<IActionResult> GetByCategoryId(Guid id, int? pageNumber, int? pageSize)
        {
            var products = await _mediator.Send(new GetProductsByCategoryIdQuery(id));
            if (products == null)
                return NotFound($"Category with id {id} not found");

            return Ok(pagination(products, pageNumber, pageSize));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var command = new AddProductCommand()
            {
                Name = productDto.Name,
                CategoryId = productDto.CategoryId,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
                ImageUrl = await GetPath(productDto.ImageUrl, "Products")
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
                ImageUrl = await GetPath(productDto.ImageUrl, "Products")
            };

            var success = await _mediator.Send(productCommand);
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
        private async Task<string?> GetPath(IFormFile? file, string? folder)
        {
            if (file == null || folder == null)
                return null;
            var uploads = Path.Combine(_environment.WebRootPath, folder);
            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filepath = Path.Combine(uploads, fileName);

            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return $"/{folder}/{fileName}";
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
