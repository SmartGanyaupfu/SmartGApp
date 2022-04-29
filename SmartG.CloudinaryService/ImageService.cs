﻿using System;
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

        public async Task<ImageUploadResult> AddImageAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream)
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<DeletionResult> DeleteImageAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }
    }
}

