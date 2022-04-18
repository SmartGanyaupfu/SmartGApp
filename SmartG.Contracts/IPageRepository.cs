using System;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

namespace SmartG.Contracts
{
    public interface IPageRepository
    {
        Task<PagedList<Page>> GetAllPagesAsync(PageParameters pageParameters, bool trackChanges);
        Task<Page> GetPageByIdAsync(int pageId, bool trackChanges);
        void CreatePageAsync(Page page);
        void DeletePageAsync(Page page);
        void UpdatePageAsync(Page page);
    }
}

