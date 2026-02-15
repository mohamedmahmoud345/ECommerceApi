namespace Core.Entities
{
    public class Customer
    {
        public Customer(string name, string address, string phone, Guid userId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(name));
            Id = Guid.NewGuid();
            Name = name;
            Address = address;
            Phone = phone;
            CreatedAt = DateTime.UtcNow;
            UserId = userId;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Cart? Cart { get; private set; }
        public Guid UserId { get; private set; }
        public void Rename(string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required" , nameof(name));
            Name = name; 
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
