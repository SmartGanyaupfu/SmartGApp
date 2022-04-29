using System;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace SmartG.Contracts
{
    public interface IImageUploader
    {
        Task<ImageUploadResult> AddImageAsync(IFormFile file);
        Task<DeletionResult> DeleteImageAsync(string publicId);
    }
}

