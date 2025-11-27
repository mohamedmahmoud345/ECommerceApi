using Application.IUnitOfWorks;
using MediatR;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(request.Id);
            if (category == null)
                return false;

            if (request.Name != null)
                category.Rename(request.Name);
            if (request.Description != null)
                category.ChangeDescription(request.Description);


            await _unitOfWork.Categories.Update(category);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
