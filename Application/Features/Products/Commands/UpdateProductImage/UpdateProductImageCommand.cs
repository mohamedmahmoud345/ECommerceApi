using MediatR;

namespace Application.Features.Products.Commands.UpdateProductImage
{
    public class UpdateProductImageCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string ImageName { get; set; }
        public Stream ImageStream { get; set; }
    }
}
