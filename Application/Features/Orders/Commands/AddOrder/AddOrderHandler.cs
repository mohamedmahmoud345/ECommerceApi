using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;
using Core.Entities;
using Core.Enums;
namespace Application.Features.Orders.Commands.AddOrder
{
    public class AddOrderHandler : IRequestHandler<AddOrderCommand, AddOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddOrderHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddOrderResponse> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(request.CustomerId, asNoTracking: true);
            if (customer is null)
                return null;

            var cart = await _unitOfWork.Carts.GetByCustomerIdAsync(customer.Id);
            if (cart is null || !cart.Items.Any())
                return null;

            var order = new Order(OrderStatus.Pending, customer.Id);
            foreach (var cartItem in cart.Items)
            {
                order.AddItem(cartItem.ProductId, cartItem.Quantity, cartItem.Price);
            }
            await _unitOfWork.Orders.AddAsync(order);
            var payment =
                new Payment(order.Id, order.TotalAmount, request.PaymentMethod, PaymentStatus.Pending, DateTime.Now);
            await _unitOfWork.Payments.AddAsync(payment);
            cart.ClearCart();
            await _unitOfWork.SaveChangesAsync();

            var response = _mapper.Map<AddOrderResponse>(order);

            return response;
        }
    }
}
