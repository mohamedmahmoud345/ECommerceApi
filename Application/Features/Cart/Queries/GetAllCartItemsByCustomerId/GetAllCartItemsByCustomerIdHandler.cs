using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Cart.Queries.GetAllCartItemsByCustomerId
{
    public class GetAllCartItemsByCustomerIdHandler
        : IRequestHandler<GetAllCartItemsByCustomerIdQuery, GetAllCartItemsByCustomerIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllCartItemsByCustomerIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetAllCartItemsByCustomerIdResponse?> Handle(GetAllCartItemsByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(request.CustomerId);
            if (customer == null)
                return null;

            var items = await _unitOfWork.Carts.GetByCustomerIdAsync(request.CustomerId);
            if (!await _unitOfWork.Carts.HasActiveCartAsync(customer.Id) || !items.Items.Any())
                return new GetAllCartItemsByCustomerIdResponse();

            var mapper = _mapper.Map<GetAllCartItemsByCustomerIdResponse>(items);


            return mapper;
        }
    }
}
