
using Microsoft.AspNetCore;

namespace Zay.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment webHost;

        public ImageService(IWebHostEnvironment webHost)
            => webHost = webHost;
        public string SaveImage(IFormFile newFile)
        {
            if (newFile == null || newFile.Length == 0)
                throw new ArgumentException("File is empty or null");
            
            var uniqueFileName = $"{Guid.NewGuid().ToString()}_{newFile.FileName}";

            var uploadsFolder = Path.Combine(webHost.WebRootPath, "images");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                newFile.CopyTo(fileStream);
            }

            return Path.Combine("images", uniqueFileName);
        }
    }
}
