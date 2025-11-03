namespace Core.Entities
{
    public class Customer
    {
        public Customer(string name, string email, string address, string phone)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(name));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required", nameof(email));
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ICollection<Cart> Cart { get; private set; } = new List<Cart>();
        public void Update(string? name, string? email, string? phone, string? address)
        {
            if(!string.IsNullOrWhiteSpace(name))
                Name = name;
            if(!string.IsNullOrWhiteSpace(email))
                Email = email;
            if (!string.IsNullOrWhiteSpace(phone))
                Phone = phone;
            if (!string.IsNullOrWhiteSpace(address))
                Address = address;
        }
    }
}
