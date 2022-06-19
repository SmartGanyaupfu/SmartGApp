using System;
using Microsoft.EntityFrameworkCore;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

namespace SmartG.Repository
{
    public class ContentBlockRepository : GenericRepositoryBase<ContentBlock>, IContentBlockRepository
    {
        public ContentBlockRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateContentBlockAsync(ContentBlock contentBlock)
        {
            Create(contentBlock);
        }

        public void DeleteContentBlockAsync(ContentBlock contentBlock)
        {
            Delete(contentBlock);
        }

        public async Task<ContentBlock> GetContentBlockByIdAsync(Guid contentBlockId, bool trackChanges)
        {
            return await FindByCondition(c => c.ContentBlockId.Equals(contentBlockId), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<PagedList<ContentBlock>> GetContentBlocksAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var blocks = await FindAll(trackChanges).OrderByDescending(p => p.Title).ToListAsync();
            return PagedList<ContentBlock>.ToPagedList(blocks, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public void UpdateContentBlockAsync(ContentBlock contentBlock)
        {
            Update(contentBlock);
        }
    }
}

