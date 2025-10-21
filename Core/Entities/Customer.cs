namespace Core.Entities
{
    public class Customer
    {
        public Customer(string name, string email, string passwordHash, string address, string phone)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Address = address;
            Phone = phone;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string PasswordHash { get; private set; }
        public string Address { get; private set; }
        public void UpdateContact(string phone, string address)
        {
            Phone = phone;
            Address = address;
        }
    }
}
