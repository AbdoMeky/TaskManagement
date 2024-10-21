using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;

namespace Store.DataAccess.Helpers
{
    public static class ImageHelper
    {
        private static readonly string ImageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "products");

        static ImageHelper()
        {
            if (!Directory.Exists(ImageDirectory))
            {
                Directory.CreateDirectory(ImageDirectory);
            }
        }

        public static async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            if (imageFile.Length > 0)
            {
               
                var fileName = Path.GetFileName(imageFile.FileName);
                var hash = ComputeHash(imageFile);
                var newFileName = $"{hash}{Path.GetExtension(fileName)}"; 

                var filePath = Path.Combine(ImageDirectory, newFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                return $"/images/products/{newFileName}"; 
            }

            return null;
        }

        private static string ComputeHash(IFormFile file)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = file.OpenReadStream())
                {
                    var hashBytes = sha256.ComputeHash(stream);
                    var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower(); // تحويل إلى string
                    return hashString;
                }
            }
        }
    }
}
