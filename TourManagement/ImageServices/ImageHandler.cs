using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TourManagement.ImageServices
{
    public interface IImageHandler
    {
        Task<IActionResult> UploadImage(IFormFile file, string owner, string imgname);
        IActionResult RemoveImage(string owner, string imgname);
        IActionResult RenameImage(string owner, string oldname, string newname);
        Task<string> GetLocationOfUploadedImage(IFormFile image, string owner, string imageName = null);
    }
    public class ImageHandler : IImageHandler
    {
        private readonly IImageWriter _imageWriter;

        public ImageHandler(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }

        public async Task<IActionResult> UploadImage(IFormFile file, string owner, string imgname)
        {
            var result = await _imageWriter.UploadImage(file, owner, imgname);
            return new ObjectResult(result);
        }
        public IActionResult RemoveImage(string owner, string imgname)
        {
            string result = _imageWriter.RemoveImage(owner, imgname);
            return new ObjectResult(result);
        }
        public IActionResult RenameImage(string owner, string oldname, string newname)
        {
            string result = _imageWriter.RenameImage(owner, oldname, newname);
            return new ObjectResult(result);
        }


        public async Task<string> GetLocationOfUploadedImage(IFormFile image, string owner, string imageName = null)
        {
            string extension = "." + image.FileName.Split('.')[image.FileName.Split('.').Length - 1];
            string location = imageName ?? Guid.NewGuid().ToString("D");
            location += extension;
            await _imageWriter.UploadImage(image, owner, location);
            return location;
        }
    }
}
