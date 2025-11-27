namespace Core.Entities
{
    public class Review
    {
        public Review(string comment, int rating, Guid customerId, Guid productId)
        {
            Id = Guid.NewGuid();
            if (string.IsNullOrWhiteSpace(comment))
                throw new ArgumentException(nameof(comment));
            Comment = comment;
            if (rating < 1 || rating > 5)
                throw new ArgumentException(nameof(rating));
            Rating = rating;
            CreatedAt = DateTime.Now;
            CustomerId = customerId;
            ProductId = productId;
        }

        public Guid Id { get; private set; }
        public string Comment { get; private set; }
        public int Rating { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }

        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }

        public void UpdateComment(string newComment)
        {
            if (string.IsNullOrWhiteSpace(newComment))
                throw new ArgumentException(nameof(newComment));
            Comment = newComment;
        }
        public void UpdateRating(int rating)
        {
            if (rating < 1 || rating > 5) throw new ArgumentException(nameof(rating));
            Rating = rating;
        }
    }
}
