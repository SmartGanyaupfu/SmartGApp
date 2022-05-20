using System;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

namespace SmartG.Contracts
{
    public interface IPortfolioRepository
    {
        Task<PagedList<Portfolio>> GetAllPortfoliosAsync(RequestParameters requestParameters, bool trackChanges);
        Task<Portfolio> GetPortfolioByIdAsync(Guid portfolioId, bool trackChanges);
        Task<Portfolio> GetPortfolioBySlugNameAsync(string slug, bool trackChanges);
        void CreatePortfolioAsync(Portfolio portfolio);
        void DeletePortfolioAsync(Portfolio portfolio);
        void UpdatePortfolioAsync(Portfolio portfolio);
    }
}

