using System;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

namespace SmartG.Contracts
{
    public interface IContentBlockRepository
    {
        Task<PagedList<ContentBlock>> GetContentBlocksAsync(RequestParameters requestParameters, bool trackChanges);
        Task<ContentBlock> GetContentBlockByIdAsync(Guid contentBlockId, bool trackChanges);
        void CreateContentBlockAsync(ContentBlock contentBlock);
        void DeleteContentBlockAsync(ContentBlock contentBlock);
        void UpdateContentBlockAsync(ContentBlock contentBlock);
    }
}

