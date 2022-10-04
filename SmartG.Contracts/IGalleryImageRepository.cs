using System;
using SmartG.Entities.Models;

namespace SmartG.Contracts
{
    public interface IGalleryImageRepository
    {
        Task<IEnumerable<GalleryImage>> GetGalleryImagesAsync(int galleryId,bool trackChanges);
        Task<GalleryImage> GetGalleryImageByIdAsync(int Id, bool trackChanges);
        void CreateGalleryImageAsync( GalleryImage galleryImage);
        void DeleteGalleryImageAsync(GalleryImage galleryImage);
        void UpdateGalleryImageAsync(GalleryImage galleryImage);
    }
}

