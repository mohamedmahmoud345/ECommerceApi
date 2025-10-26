using Application.Dto.CartDto;
using Application.Interfaces.IServices;
using Application.IUnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var carts = await cartService.GetByIdAsync(id);

            return Ok(carts);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CartDto cart)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            await cartService.AddAsync(cart);
            return Created();
        }
    }
}
