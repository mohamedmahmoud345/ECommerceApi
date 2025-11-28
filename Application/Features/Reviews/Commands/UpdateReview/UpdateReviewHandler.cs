using Application.IUnitOfWorks;
using MediatR;

namespace Application.Features.Reviews.Commands.UpdateReview
{
    public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateReviewHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.Reviews.GetByIdAsync(request.Id);
            if (review == null)
                return false;

            if (request.Comment != null)
                review.UpdateComment(request.Comment);

            if (request.Rating.HasValue)
                review.UpdateRating(request.Rating.Value);

            var product = await _unitOfWork.Products.GetByIdAsync(review.ProductId, true);
            product.RemoveReview(review.Id);

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
