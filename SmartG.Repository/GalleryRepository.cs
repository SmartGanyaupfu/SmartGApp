using System;
using Microsoft.EntityFrameworkCore;
using SmartG.Contracts;
using SmartG.Entities.Models;

namespace SmartG.Repository
{
    public class GalleryRepository:GenericRepositoryBase<Gallery>, IGalleryRepository
    {

        public GalleryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateGallerAsync(Entities.Models.Gallery gallery)
        {
            Create(gallery);
        }

        public void DeleteGalleryAsync(Entities.Models.Gallery gallery)
        {
            Delete(gallery);
        }

        public async Task<IEnumerable<Entities.Models.Gallery>> GetGalleryAsync(bool trackChanges)
        {
            var galleryList = await FindAll(trackChanges).ToListAsync();
            return galleryList;
        }

        public async Task<Entities.Models.Gallery> GetGalleryByIdAsync(int galleryId, bool trackChanges)
        {
            return await FindByCondition(g => g.GalleryId.Equals(galleryId),trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateGalleryAsync(Entities.Models.Gallery gallery)
        {
            Update(gallery);
        }
    }



}