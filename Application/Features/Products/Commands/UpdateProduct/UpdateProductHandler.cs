
using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id);
            if (product == null)
                return false;
            var category = _unitOfWork.Categories.GetByIdAsync(request.CategoryId);
            if (category == null) 
                return false;
            else
                product.ChangeCategory(request.CategoryId);

            if (!string.IsNullOrWhiteSpace(request.Name))
                product.Rename(request.Name);
            if (!string.IsNullOrWhiteSpace(request.Description))
                product.ChangeDescription(request.Description);
            if(request.StockQuantity != null && request.StockQuantity.Value > 0)
                product.UpdateStockQuantity(request.StockQuantity.Value);
            if(request.Price != null && request.Price.Value > 0)
                product.UpdatePrice(request.Price.Value);
            if(!string.IsNullOrWhiteSpace(request.ImageUrl))
                product.ChangePhoto(request.ImageUrl);

            await _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync();

            return true;

        }
    }
}
