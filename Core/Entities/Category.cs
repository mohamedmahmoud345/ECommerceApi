

namespace Core.Entities
{
    public class Category
    {
        public Category(string name , string description, Guid? adminId)
        {
            Id = Guid.NewGuid();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(name));
            Name = name;
            Description = description;
            AdminId = adminId;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Admin? Admin { get; private set; }
        public Guid? AdminId { get; private set; }
        public void UpdateDescription(string description) => Description = description;
        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Name is required", nameof(newName));
            Name = newName;
        }
    }
}
