using Application.IUnitOfWorks;
using MediatR;

namespace Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOkwork;

        public DeleteCategoryHandler(IUnitOfWork unitOkwork)
        {
            _unitOkwork = unitOkwork;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOkwork.Categories.GetByIdAsync(request.Id);
            if (category is null)
                return false;

            await _unitOkwork.Categories.DeleteAsync(request.Id);
            await _unitOkwork.SaveChangesAsync();

            return true;
        }
    }
}
