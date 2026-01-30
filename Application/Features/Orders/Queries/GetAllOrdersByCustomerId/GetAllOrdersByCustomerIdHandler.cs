using System;
using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Orders.Queries.GetAllOrdersByCustomerId
{
    public class GetAllOrdersByCustomerIdHandler :
    IRequestHandler<GetAllOrdersByCustomerIdQuery, GetAllOrdersByCustomerIdResponse?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllOrdersByCustomerIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetAllOrdersByCustomerIdResponse?> Handle(GetAllOrdersByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(request.CustomerId);
            if (customer is null)
                return null;

            var cart = await _unitOfWork.Carts.GetByCustomerIdAsync(request.CustomerId);
            if (cart is null && !cart!.Items.Any())
                return null;

            var response = _mapper.Map<GetAllOrdersByCustomerIdResponse>(cart.Items);

            return response;
        }
    }
}
