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
            var cart = await _unitOfWork.Carts.GetByCustomerIdAsync(request.CustomerId, asNoTracking: false);
            var product = await _unitOfWork.Products.GetByIdAsync(request.ProductId, asNoTracking: true);

            if (product == null)
                return null;

            bool isNewCart = cart == null;

            if (isNewCart)
            {
                cart = new Core.Entities.Cart(request.CustomerId);
            }

            cart.AddItem(product, request.Quantity);  

            if (isNewCart)
                await _unitOfWork.Carts.AddAsync(cart); 

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<AddItemToCartResponse>(cart);
        }
    }
}