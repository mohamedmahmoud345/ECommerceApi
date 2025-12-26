namespace Application.Interfaces.Services
{
    public interface IFileStorageService
    {
        Task<string> SaveAsync(Stream stream, string fileName, string folder);
        Task DeleteAsync(string filePath);
    }
}
