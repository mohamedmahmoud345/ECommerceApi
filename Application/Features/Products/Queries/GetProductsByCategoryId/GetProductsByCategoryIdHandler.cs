
using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Queries.GetProductsByCategoryId
{
    public class GetProductsByCategoryIdHandler : IRequestHandler<GetProductsByCategoryIdQuery, List<GetProductsByCategoryIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductsByCategoryIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetProductsByCategoryIdResponse?>> Handle(GetProductsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var isIdValid = await _unitOfWork.Categories.GetByIdAsync(request.Id);
            if (isIdValid == null)
                return null;

            var products = await _unitOfWork.Products.GetByCategoryIdAsync(request.Id);

            return _mapper.Map<List<GetProductsByCategoryIdResponse>>(products);
        }
    }
}
