
using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Reviews.Queries.GetReviewById
{
    public class GetReviewByIdHandler : IRequestHandler<GetReviewByIdQuery, GetReviewByIdResponse?>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetReviewByIdHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetReviewByIdResponse?> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.Reviews.GetByIdAsync(request.Id, true);
            if (review == null)
                return null;

            return _mapper.Map<GetReviewByIdResponse>(review);
        }
    }
}
