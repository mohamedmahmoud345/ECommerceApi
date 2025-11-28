using Application.IUnitOfWorks;
using AutoMapper;
using Core.Entities;
using MediatR;

namespace Application.Features.Reviews.Commands.AddReview
{
    public class AddReviewHandler : IRequestHandler<AddReviewCommand, AddReviewResponse?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddReviewHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddReviewResponse?> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(request.CustomerId, true);
            if (customer == null)
                return null;

            var product = await _unitOfWork.Products.GetByIdAsync(request.ProductId);
            if (product == null)
                return null;

            var review = new Review(request.Comment, request.Rating, request.CustomerId, request.ProductId);

            product.AddReview(review);

            var reviewResponse = await _unitOfWork.Reviews.AddAsync(review);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<AddReviewResponse?>(reviewResponse);
        }
    }
}
