
using Application.Interfaces.Services;
using Application.IUnitOfWorks;
using MediatR;

namespace Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _storageService;
        public DeleteProductHandler(IUnitOfWork unitOfWork, IFileStorageService storageService)
        {
            _unitOfWork = unitOfWork;
            _storageService = storageService;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id);
            if (product == null)
                return false;


            await _unitOfWork.Products.DeleteAsync(request.Id);
            await _storageService.DeleteAsync(product.ImageUrl);
            await _unitOfWork.SaveChangesAsync();


            return true;
        }
    }
}
