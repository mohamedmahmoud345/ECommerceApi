using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Reviews.Queries.GetAllReviewsByCustomerId
{
    public class GetAllReviewsByCustomerIdHandler :
        IRequestHandler<GetAllReviewsByCustomerIdQuery, List<GetAllReviewsByCustomerIdResponse>?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllReviewsByCustomerIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllReviewsByCustomerIdResponse>?> Handle(GetAllReviewsByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _unitOfWork.Reviews.GetByCustomerIdAsync(request.CustomerId);

            if (reviews == null)
                return new List<GetAllReviewsByCustomerIdResponse>();

            return _mapper.Map<List<GetAllReviewsByCustomerIdResponse>>(reviews);
        }
    }
}
