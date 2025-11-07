
using Application.IUnitOfWorks;
using AutoMapper;
using Core.Entities;
using MediatR;

namespace Application.Features.Products.Commands.AddProduct
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, AddProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddProductResponse?> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var validCategory = await _unitOfWork.Categories.GetByIdAsync(request.CategoryId);
            if (validCategory == null)
                return null;            

            var product = new Product(request.Name, request.Description,request.ImageUrl ,request.Price, request.StockQuantity, request.CategoryId);
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<AddProductResponse>(product);
        }
    }
}
