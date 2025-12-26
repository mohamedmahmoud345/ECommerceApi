using Application.Interfaces.Services;

namespace Infrastructure.Services
{
    public class LocalFileStorageService : IFileStorageService
    {
        private readonly IFilePathProvider _path;
        public LocalFileStorageService(IFilePathProvider pathProvider)
        {
            _path = pathProvider;
        }
        public async Task<string> SaveAsync(Stream stream, string fileName, string folder)
        {
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("File name cannot be empty", nameof(fileName));
            if (string.IsNullOrEmpty(folder))
                throw new ArgumentNullException("Folder cannot be empty", nameof(folder));

            var uploadPath = Path.Combine(_path.WebRootPath(), folder);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var extension = Path.GetExtension(fileName);
            var uniqueFileName = $"{Guid.NewGuid()}{extension}";

            var fullPath = Path.Combine(uploadPath, uniqueFileName);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await stream.CopyToAsync(fileStream);
            }

            return $"{folder}\\{uniqueFileName}";
        }
        public async Task DeleteAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException(nameof(filePath));

            var fullPath = Path.Combine(_path.WebRootPath(), filePath);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            else
            {
                throw new ArgumentException("File path is not found");
            }
        }
    }
}
