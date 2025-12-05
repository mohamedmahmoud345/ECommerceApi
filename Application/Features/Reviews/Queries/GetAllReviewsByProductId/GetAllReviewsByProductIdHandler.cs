using Application.Common;
using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Reviews.Queries.GetAllReviewsByProductId
{
    public class GetAllReviewsByProductIdHandler : IRequestHandler<GetAllReviewsByProductIdQuery, PageResult<GetAllReviewsByProductIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllReviewsByProductIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PageResult<GetAllReviewsByProductIdResponse>> Handle(GetAllReviewsByProductIdQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _unitOfWork.Reviews.GetByProductIdAsync(request.ProductId);

            if (reviews == null)
                return new PageResult<GetAllReviewsByProductIdResponse>();

            var data = reviews.AsQueryable();

            var pagedResult = await data.ToPagedResultAsync(request.Page, request.PageSize);

            var mappedData = _mapper.Map<IEnumerable<GetAllReviewsByProductIdResponse>>(pagedResult.Data);

            return new PageResult<GetAllReviewsByProductIdResponse>()
            {
                Page = pagedResult.Page,
                PageSize = pagedResult.PageSize,
                Count = pagedResult.Count,
                Data = mappedData
            };

        }
    }
}
