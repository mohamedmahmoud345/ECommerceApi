using Application.Common;
using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, PageResult<GetAllCategoriesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<PageResult<GetAllCategoriesResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            if (categories == null || !categories.Any())
                return new PageResult<GetAllCategoriesResponse>();

            var data = categories.AsQueryable();

            var pagedReuslt = await data.ToPagedResultAsync(request.Page, request.PageSize);

            var mappedReuslt = _mapper.Map<IEnumerable<GetAllCategoriesResponse>>(pagedReuslt.Data);

            return new PageResult<GetAllCategoriesResponse>()
            {
                Count = pagedReuslt.Count,
                PageSize = pagedReuslt.PageSize,
                Page = pagedReuslt.Page,
                Data = mappedReuslt
            };
        }
    }
}
