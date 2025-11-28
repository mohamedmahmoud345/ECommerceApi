namespace Application.Features.Reviews.Queries.GetAllReviewsByProductId
{
    public class GetAllReviewsByProductIdResponse
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
