

using Application.Common;
using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, PageResult<GetAllCustomersResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCustomersHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PageResult<GetAllCustomersResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _unitOfWork.Customers.GetAllAsync();
            if (!customers.Any())
                return new PageResult<GetAllCustomersResponse>();

            var data = customers.AsQueryable();
            
            var pagedResult = await data.ToPagedResultAsync(request.Page, request.PageSize);
            
            var mappedResult = _mapper.Map<IEnumerable<GetAllCustomersResponse>>(pagedResult.Data);

            return new PageResult<GetAllCustomersResponse>()
            {
                Count = pagedResult.Count,
                PageSize = pagedResult.PageSize,
                Page = pagedResult.Page,
                Data = mappedResult
            };
        }
    }
}
