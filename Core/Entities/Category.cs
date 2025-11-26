

namespace Core.Entities
{
    public class Category
    {
        public Category(string name, string description)
        {
            Id = Guid.NewGuid();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(name));
            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public void UpdateDescription(string description) => Description = description;
        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Name is required", nameof(newName));
            Name = newName;
        }
        public void ChangeDescription(string newDesc)
        {
            if (string.IsNullOrWhiteSpace(newDesc))
                throw new ArgumentException("Discription is required", nameof(newDesc));
            Description = newDesc;
        }
    }
}
