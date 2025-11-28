using Application.IUnitOfWorks;
using MediatR;

namespace Application.Features.Reviews.Commands.RemoveReview
{
    public class RemoveReviewHandler : IRequestHandler<RemoveReviewCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveReviewHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(RemoveReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.Reviews.GetByIdAsync(request.Id);
            if (review == null)
                return false;

            await _unitOfWork.Reviews.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
