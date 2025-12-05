namespace Api.Dto.Review;

public record AddReviewDto(string Comment ,
    int Rating, Guid CustomerId , Guid ProductId);