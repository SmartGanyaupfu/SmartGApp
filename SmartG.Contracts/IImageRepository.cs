using System;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

namespace SmartG.Contracts
{
    public interface IImageRepository
    {
        Task<PagedList<Image>> GetAllImagesAsync(RequestParameters requestParameters, bool trackChanges);
        Task<Image> GetImageByIdAsync(int imageId, bool trackChanges);
        void CreateImagesAsync(List<Image> image);
        void DeleteImageAsync(Image image);
        void UpdateImageAsync(Image image);
    }
}

