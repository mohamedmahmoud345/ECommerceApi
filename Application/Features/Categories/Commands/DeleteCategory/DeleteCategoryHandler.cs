using Application.IUnitOfWorks;
using MediatR;

namespace Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfwork;

        public DeleteCategoryHandler(IUnitOfWork unitOkwork)
        {
            _unitOfwork = unitOkwork;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfwork.Categories.GetByIdAsync(request.Id);
            if (category is null)
                return false;

            await _unitOfwork.Categories.DeleteAsync(request.Id);
            await _unitOfwork.SaveChangesAsync();

            return true;
        }
    }
}
