using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Cart.Queries.GetAllCartItemsByCustomerId
{
    public class GetAllCartItemsByCustomerIdHandler
        : IRequestHandler<GetAllCartItemsByCustomerIdQuery, List<GetAllCartItemsByCustomerIdResponse>?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllCartItemsByCustomerIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllCartItemsByCustomerIdResponse>?> Handle(GetAllCartItemsByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(request.CustomerId);
            if (customer == null)
                return null;

            var items = await _unitOfWork.Carts.GetByCustomerIdAsync(request.CustomerId);
            if (!items.Items.Any())
                return new List<GetAllCartItemsByCustomerIdResponse>();

            var mapper = _mapper.Map<List<GetAllCartItemsByCustomerIdResponse>>(items.Items);


            return mapper;
        }
    }
}
