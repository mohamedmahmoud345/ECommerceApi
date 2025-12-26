using Application.Interfaces.Services;
using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Commands.UpdateProductImage
{
    public class UpdateProductImageHandler : IRequestHandler<UpdateProductImageCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;

        public UpdateProductImageHandler(IUnitOfWork unitOfWork, IMapper mapper, IFileStorageService fileStorageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
        }

        public async Task<bool> Handle(UpdateProductImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id);
            if (product is null)
                return false;

            var oldPath = product.ImageUrl;

            var imagePath = await _fileStorageService.SaveAsync(
                    request.ImageStream,
                    request.ImageName,
                    "Products"
                );

            if (imagePath is not null)
                product.ChangePhoto(imagePath);
            await _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync();
            await _fileStorageService.DeleteAsync(oldPath);


            return true;
        }
    }
}
