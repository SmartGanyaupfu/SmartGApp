using System;
using Microsoft.EntityFrameworkCore;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

namespace SmartG.Repository
{
    public class ImageRepository : GenericRepositoryBase<Image>, IImageRepository
    {
       
        public ImageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateImageAsync(Image image)
        {
            Create(image);
        }

        public void DeleteImageAsync(Image image)
        {
            Delete(image);
        }

        public async Task<PagedList<Image>> GetAllImagesAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var images = await FindAll(trackChanges).ToListAsync();

            return PagedList<Image>.ToPagedList(images, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<Image> GetImageByIdAsync(int imageId, bool trackChanges)
        {
            return await FindByCondition(i => i.ImageId.Equals(imageId), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateImageAsync(Image image)
        {
            Update(image);
        }
    }
}

