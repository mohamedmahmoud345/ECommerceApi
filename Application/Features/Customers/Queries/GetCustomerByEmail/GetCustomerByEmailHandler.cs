
using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Customers.Queries.GetCustomerByEmail
{
    public class GetCustomerByEmailHandler : 
        IRequestHandler<GetCustomerByEmailQuery, GetCustomerByEmailResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCustomerByEmailHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetCustomerByEmailResponse> Handle(GetCustomerByEmailQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetByEmailAsync(request.Email);
            if (customer == null)
                return null;

            return _mapper.Map<GetCustomerByEmailResponse>(customer);
        }
    }
}
