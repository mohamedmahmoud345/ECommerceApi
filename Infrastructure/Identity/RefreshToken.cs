namespace Infrastructure.Identity
{
    public class RefreshToken
    {
        private RefreshToken() { }

        public RefreshToken(string token, Guid userId, DateTime expiresOnUtc)
        {
            Id = Guid.NewGuid();
            Token = token;
            UserId = userId;
            ExpiresOnUtc = expiresOnUtc;
        }

        public Guid Id { get; private set; }
        public string Token { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime ExpiresOnUtc { get; private set; }
        public DateTime? RevokedAt { get; private set; }

        public bool IsExpired => DateTime.UtcNow > ExpiresOnUtc;
        public bool IsRevoked => RevokedAt != null;

        public void Revoke()
        {
            if (IsRevoked)
                throw new InvalidOperationException("Token is already revoked.");
            RevokedAt = DateTime.UtcNow;
        }

        public ApplicationUser ApplicationUser { get; private set; }
    }
}
