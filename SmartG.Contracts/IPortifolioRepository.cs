using System;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

namespace SmartG.Contracts
{
    public interface IPortifolioRepository
    {
        Task<PagedList<Portifolio>> GetAllPortifoliosAsync(RequestParameters requestParameters, bool trackChanges);
        Task<Portifolio> GetPortifolioByIdAsync(Guid portifolioId, bool trackChanges);
        Task<Portifolio> GetPortifolioBySlugNameAsync(string slug, bool trackChanges);
        void CreatePortifolioAsync(Portifolio portifolio);
        void DeletePortifolioAsync(Portifolio portifolio);
        void UpdatePortifolioAsync(Portifolio portifolio);
    }
}

