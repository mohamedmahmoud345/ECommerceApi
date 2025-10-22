namespace Core.Entities
{
    public class Customer
    {
        public Customer(string name, string email, string passwordHash, string address, string phone)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(name));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required", nameof(email));
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Password hash is required", nameof(passwordHash));
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Address = address;
            Phone = phone;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string PasswordHash { get; private set; }
        public string Address { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ICollection<Cart> Cart { get; private set; } = new List<Cart>();
        public void UpdateContact(string phone, string address)
        {
            Phone = phone;
            Address = address;
        }
    }
}
