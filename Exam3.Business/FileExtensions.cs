using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Exam3.Business
{
    public static class FileExtensions
    {
        public const string SocialMediaImagesPath = "socialmediaimages";
        public const string TeamMemberImagesPath = "temmemberimages";

        public async static Task<string> SaveAndRetrieveImageAddressAsync(this IFormFile file,string folderPath,IWebHostEnvironment env)
        {
            var rootpath = env.WebRootPath;

            var imageFolderPath = Path.Combine(rootpath, folderPath);

            if(!Directory.Exists(imageFolderPath))
                Directory.CreateDirectory(imageFolderPath);

            var imageName = Guid.NewGuid().ToString() + file.FileName;
            var imagePath = Path.Combine(imageFolderPath, imageName);

            using (var newFile = File.Create(imagePath))
            {
                await file.CopyToAsync(newFile);
            }

            return Path.Combine(folderPath,imageName);
        }


    }
}
