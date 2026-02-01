using System;
using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Orders.Queries.GetByOrderId
{
    public class GetByOrderIdHandler :
     IRequestHandler<GetByOrderIdQuery, GetByOrderIdResponse>

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetByOrderIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetByOrderIdResponse> Handle(GetByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(request.Id);
            if (order is null)
                return null;

            var mapResult = _mapper.Map<GetByOrderIdResponse>(order);
            return mapResult;
        }
    }
}
