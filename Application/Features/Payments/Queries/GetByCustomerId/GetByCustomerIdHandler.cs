using System;
using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Payments.Queries.GetByCustomerId
{
    public class GetByCustomerIdHandler
        : IRequestHandler<GetByCustomerIdQuery, GetByCustomerIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetByCustomerIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetByCustomerIdResponse> Handle(GetByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(request.CustomerId);
            if (customer is null)
                return null;

            var payment = await _unitOfWork.Payments.GetByCustomerIdAsync(customer.Id);
            if (payment is null)
                return null;

            var response = _mapper.Map<GetByCustomerIdResponse>(payment);

            return response;
        }
    }
}
