namespace Core.Entities
{
    public class Admin
    {
        public Admin( string name, string email, string role)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(name));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required", nameof(email));
            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("Role is required", nameof(role));
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Role = role;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }
    }
}
