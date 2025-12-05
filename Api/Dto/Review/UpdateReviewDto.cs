namespace Api.Dto.Review;

public record UpdateReviewDto(Guid Id,
        string? Comment, int? Rating);