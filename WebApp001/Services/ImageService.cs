using System;
using System.IO;
using System.Threading.Tasks;
using WebApp001.Models;

namespace WebApp001.Services
{
    public class ImageService
    {
        private readonly PathService pathService;

        public ImageService(PathService pathService)
        {
            this.pathService = pathService;
        }

        public async Task<Image> UploadAsync(Image image)
        {
            var uploadsPath = pathService.GetUploadsPath();
            var imageFile = image.File;
            var imageFileName = GetRandomFileName(imageFile.FileName);
            var imageUploadPath = Path.Combine(uploadsPath, imageFileName);

            using (var fs = new FileStream(imageUploadPath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fs);
            }

            image.Name = imageFile.FileName;
            image.Path = pathService.GetUploadsPath(imageFileName, withWebRootPath: false);

            return image;
        }

        private string GetRandomFileName(string filename)
        {
            return Guid.NewGuid() + Path.GetExtension(filename);
        }
    }
}
