using System;
using Microsoft.EntityFrameworkCore;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

namespace SmartG.Repository
{
    public class PageRepository : GenericRepositoryBase<Page>, IPageRepository
    {
        public PageRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {

        }

        public void CreatePageAsync(Page page)
        {
            Create(page);
        }

        public void DeletePageAsync(Page page)
        {
            Delete(page);
        }

        public async Task<PagedList<Page>> GetAllPagesAsync(PageParameters pageParameters, bool trackChanges)
        {
            var pages = await FindAll(trackChanges).ToListAsync();
            var pr = PagedList<Page>.ToPagedList(pages, pageParameters.PageNumber, pageParameters.PageSize);
            return pr;
        }

        public async Task<Page> GetPageByIdAsync(int pageId, bool trackChanges)
        {
            return await FindByCondition(p => p.PageId.Equals(pageId), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdatePageAsync(Page page)
        {
            Update(page);
        }
    }
}

