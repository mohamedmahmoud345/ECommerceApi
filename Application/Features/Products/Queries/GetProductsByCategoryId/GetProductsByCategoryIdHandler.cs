
using Application.Common;
using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Queries.GetProductsByCategoryId
{
    public class GetProductsByCategoryIdHandler : IRequestHandler<GetProductsByCategoryIdQuery, PageResult<GetProductsByCategoryIdResponse?>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductsByCategoryIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PageResult<GetProductsByCategoryIdResponse?>> Handle(GetProductsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var isExist = await _unitOfWork.Categories.GetByIdAsync(request.Id);
            if (isExist == null)
                return null;

            var products = await _unitOfWork.Products.GetByCategoryIdAsync(request.Id);

            if (products == null || !products.Any())
                return new PageResult<GetProductsByCategoryIdResponse?>();

            var data = products.AsQueryable();

            var pagedResult = await data.ToPagedResultAsync(request.Page, request.PageSize);
            var mappedResult = _mapper.Map<IEnumerable<GetProductsByCategoryIdResponse>>(pagedResult.Data);

            return new PageResult<GetProductsByCategoryIdResponse?>()
            {
                Count = pagedResult.Count,
                PageSize = pagedResult.PageSize,
                Page = pagedResult.Page,
                Data = mappedResult
            };
        }
    }
}
