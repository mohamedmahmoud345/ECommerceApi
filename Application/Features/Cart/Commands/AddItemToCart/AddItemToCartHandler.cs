using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Cart.Commands.AddItemToCart
{
    public class AddItemToCartHandler : IRequestHandler<AddItemToCartCommand, AddItemToCartResponse?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddItemToCartHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddItemToCartResponse?> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _unitOfWork.Carts.GetByCustomerIdAsync(request.CustomerId);
            if (cart == null)
            {
                cart = new Core.Entities.Cart(request.CustomerId);
                await _unitOfWork.Carts.AddAsync(cart);
            }

            var product = await _unitOfWork.Products.GetByIdAsync(request.ProductId);
            if (product == null)
                return null;

            cart.AddItem(product, request.Quantity);
            await _unitOfWork.SaveChangesAsync();

            var cartResult = _mapper.Map<AddItemToCartResponse>(cart);


            return cartResult;
        }
    }
}