﻿using System;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

namespace SmartG.Contracts
{
    public interface IGalleryRepository
    {
        Task<IEnumerable<Gallery>> GetGalleryAsync(bool trackChanges);
        Task<Gallery> GetGalleryByIdAsync(int galleryId, bool trackChanges);
        Task<Gallery> GetGalleryForUpdateByIdAsync(int galleryId, bool trackChanges);
        void CreateGalleryAsync(Gallery gallery);
        void DeleteGalleryAsync(Gallery gallery);
        void UpdateGalleryAsync(Gallery gallery);
    }
}

