namespace Core.Entities
{
    public class Admin
    {
        public Admin( string name, string email, string role)
        {
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
