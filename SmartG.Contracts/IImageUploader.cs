using System;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace SmartG.Contracts
{
    public interface IImageUploader
    {
        Task<List<ImageUploadResult>> AddImageAsync(IFormFile [] file);
        Task<DeletionResult> DeleteImageAsync(string publicId);
    }
}

