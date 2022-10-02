using System;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SmartG.Contracts;

namespace SmartG.CloudinaryService
{
    public class ImageService:IImageUploader
    {
        private readonly Cloudinary _cloudinary;
        public ImageService( IOptions<CloudinarySettings> config)
        {
            var acc = new Account(
                config.Value.CloudName, config.Value.ApiKey, config.Value.ApiSecret);

            _cloudinary = new Cloudinary(acc);
        }

        public async Task<List<ImageUploadResult>> AddImageAsync(IFormFile[] files)
        {
            var uploadResult = new ImageUploadResult();
            List<ImageUploadResult> imageUploads = new List<ImageUploadResult>();
            foreach(var file in files)
            {
                if (file.Length > 0)
                {
                    using var stream = file.OpenReadStream();
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.FileName, stream),
                        Transformation = new Transformation().Width(0.5)
                    };
                    uploadResult = await _cloudinary.UploadAsync(uploadParams);
                    imageUploads.Add(uploadResult);
                    
                }
            }
           

            return imageUploads;
        }

        public async Task<DeletionResult> DeleteImageAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }
    }
}

