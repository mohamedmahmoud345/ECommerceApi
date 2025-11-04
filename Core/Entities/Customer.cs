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

        public void Rename(string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required" , nameof(name));
            Name = name; 
        }
        public void ChangeEmail(string email) 
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required" , nameof(email));
            Email = email; 
        }
        public void ChangePhone(string phone) 
        {
            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentException("Phone is required" , nameof(phone));               
            Phone = phone; 
        }
        public void ChangeAddress(string address) 
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address is required" , nameof(address));
            Address = address; 
        }
    }
}
