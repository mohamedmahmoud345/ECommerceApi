using Application.Interfaces.Services;
using Application.IUnitOfWorks;
using AutoMapper;
using Core.Entities;
using MediatR;

namespace Application.Features.Products.Commands.AddProduct
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, AddProductResponse?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileService;
        public AddProductHandler(IUnitOfWork unitOfWork, IMapper mapper, IFileStorageService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<AddProductResponse?> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            string imagePath = null;
            try
            {
                var category = await _unitOfWork.Categories.GetByIdAsync(request.CategoryId);
                if (category is null)
                    return null;

                imagePath = await _fileService.SaveAsync(
                        request.ImageStream,
                        request.ImageName,
                        "Products"
                    );


                var product = new Product(request.Name, request.Description, imagePath, request.Price, request.StockQuantity, request.CategoryId);

                await _unitOfWork.Products.AddAsync(product);
                await _unitOfWork.SaveChangesAsync();


                return _mapper.Map<AddProductResponse>(product);
            }
            catch (Exception ex)
            {
                if (imagePath != null)
                    await _fileService.DeleteAsync(imagePath);

                throw;
            }
        }
    }
}
