
using Application.Common;
using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, PageResult<GetAllProductsResponse?>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PageResult<GetAllProductsResponse?>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.Products.GetAllAsync();

            if (products == null)
                return null;
            
            if (!products.Any())
                return new PageResult<GetAllProductsResponse>();
            var data = products.AsQueryable();
            
            var pagedResult = await data.ToPagedResultAsync(request.Page, request.PageSize);
            
            var mappedResult = _mapper.Map<IEnumerable<GetAllProductsResponse>>(pagedResult.Data);
            
            return new PageResult<GetAllProductsResponse>()
            {
                Count = pagedResult.Count,
                PageSize = pagedResult.PageSize,
                Page = pagedResult.Page,
                Data = mappedResult
            }!;
        }
    }
}
