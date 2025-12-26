using Application.Interfaces.Services;

namespace Api.Services
{
    public class FilePathProvider : IFilePathProvider
    {
        private readonly IWebHostEnvironment _env;

        public FilePathProvider(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string WebRootPath()
        {
            return _env.WebRootPath;
        }
    }
}
