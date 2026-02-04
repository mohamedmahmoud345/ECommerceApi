using System;
using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Payments.Queries.GetById
{
    public class GetByIdHandler
        : IRequestHandler<GetByIdQuery, GetByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetByIdResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(request.Id);
            if (payment is null)
                return null;

            var response = _mapper.Map<GetByIdResponse>(payment);

            return response;
        }
    }
}
