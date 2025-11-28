using Application.Features.Reviews.Commands.AddReview;
using Application.Features.Reviews.Queries.GetAllReviewsByCustomerId;
using Application.Features.Reviews.Queries.GetAllReviewsByProductId;
using Application.Features.Reviews.Queries.GetReviewById;
using AutoMapper;
using Core.Entities;

namespace Application.Mapping.Reviews
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, GetReviewByIdResponse>()
                .ForMember(x => x.CustomerName, src => src.MapFrom(x => x.Customer.Name))
                .ForMember(x => x.ProductName, src => src.MapFrom(x => x.Product.Name));

            CreateMap<Review, GetAllReviewsByProductIdResponse>()
                .ForMember(x => x.CustomerName, src => src.MapFrom(x => x.Customer.Name))
                .ForMember(x => x.ProductName, src => src.MapFrom(x => x.Product.Name));

            CreateMap<Review, GetAllReviewsByCustomerIdResponse>()
                .ForMember(x => x.CustomerName, src => src.MapFrom(x => x.Customer.Name))
                .ForMember(x => x.ProductName, src => src.MapFrom(x => x.Product.Name));


            CreateMap<Review, AddReviewResponse>()
                .ForMember(x => x.CustomerName, src => src.MapFrom(x => x.Customer.Name))
                .ForMember(x => x.ProductName, src => src.MapFrom(x => x.Product.Name));
        }
    }
}
