using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Reviews.Queries.GetAllReviewsByProductId
{
    public class GetAllReviewsByProductIdHandler : IRequestHandler<GetAllReviewsByProductIdQuery, List<GetAllReviewsByProductIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllReviewsByProductIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllReviewsByProductIdResponse>> Handle(GetAllReviewsByProductIdQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _unitOfWork.Reviews.GetByProductIdAsync(request.ProductId);

            if (reviews == null)
                return new List<GetAllReviewsByProductIdResponse>();

            return _mapper.Map<List<GetAllReviewsByProductIdResponse>>(reviews);
        }
    }
}
