using Application.Common;
using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Reviews.Queries.GetAllReviewsByCustomerId
{
    public class GetAllReviewsByCustomerIdHandler :
        IRequestHandler<GetAllReviewsByCustomerIdQuery, PageResult<GetAllReviewsByCustomerIdResponse>?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllReviewsByCustomerIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PageResult<GetAllReviewsByCustomerIdResponse>?> Handle(GetAllReviewsByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _unitOfWork.Reviews.GetByCustomerIdAsync(request.CustomerId);

            if (reviews == null)
                return new PageResult<GetAllReviewsByCustomerIdResponse>();

            var data = reviews.AsQueryable();

            var pagedResult = await data.ToPagedResultAsync(request.Page, request.PageSize);

            var mappedData = _mapper.Map<IEnumerable<GetAllReviewsByCustomerIdResponse>>(pagedResult.Data);

            return new PageResult<GetAllReviewsByCustomerIdResponse>()
            {
                Count = pagedResult.Count,
                PageSize = pagedResult.PageSize,
                Page = pagedResult.Page,
                Data = mappedData
            };
        }
    }
}
