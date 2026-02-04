using System;
using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Payments.Queries.GetPaymentByOrderId
{
    public class GetPaymentByOrderIdHandler
        : IRequestHandler<GetPaymentByOrderIdQuery, GetPaymentByOrderIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetPaymentByOrderIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetPaymentByOrderIdResponse> Handle(GetPaymentByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(request.OrderId);
            if (order is null)
                return null;

            var payment = await _unitOfWork.Payments.GetByOrderId(order.Id);
            if (payment is null)
                return null;

            var response = _mapper.Map<GetPaymentByOrderIdResponse>(payment);

            return response;
        }
    }
}
