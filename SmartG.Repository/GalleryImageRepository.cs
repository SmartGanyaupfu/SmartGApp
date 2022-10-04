using System;
using Microsoft.EntityFrameworkCore;
using SmartG.Contracts;
using SmartG.Entities.Models;

namespace SmartG.Repository
{
    public class GalleryImageRepository : GenericRepositoryBase<GalleryImage>, IGalleryImageRepository
    {

        public GalleryImageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateGalleryImageAsync( GalleryImage galleryImage)
        {
           
           Create(galleryImage);
        }

        public void DeleteGalleryImageAsync(GalleryImage galleryImage)
        {Delete(galleryImage);
        }

        public async Task<GalleryImage> GetGalleryImageByIdAsync( int Id, bool trackChanges)
        {
            return await FindByCondition( i=>i.Id.Equals(Id),trackChanges).SingleOrDefaultAsync();
        }

       

        public async Task<IEnumerable<GalleryImage>> GetGalleryImagesAsync(int galleryId, bool trackChanges)
        {
            return await FindByCondition(i => i.GalleryId.Equals(galleryId), trackChanges).ToListAsync();
        }

        public void UpdateGalleryImageAsync(GalleryImage galleryImage)
        {
            Update(galleryImage);
        }
    }
}

