

using Application.IUnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<GetAllCategoriesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        async Task<List<GetAllCategoriesResponse>?> IRequestHandler<GetAllCategoriesQuery, List<GetAllCategoriesResponse>>.Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();

            return _mapper.Map<List<GetAllCategoriesResponse>>(categories);
        }
    }
}
