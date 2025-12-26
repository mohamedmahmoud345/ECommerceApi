
using MediatR;

namespace Application.Features.Products.Commands.AddProduct
{
    public class AddProductCommand : IRequest<AddProductResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public Stream ImageStream { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid CategoryId { get; set; }
    }
}
