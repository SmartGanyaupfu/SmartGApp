using System;
using Microsoft.EntityFrameworkCore;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

namespace SmartG.Repository
{
    public class PortifolioRepository:GenericRepositoryBase<Portifolio>,IPortifolioRepository
    {
        public PortifolioRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
        }

        public void CreatePortifolioAsync(Portifolio portifolio)
        {
            Create(portifolio);
        }

        public void DeletePortifolioAsync(Portifolio portifolio)
        {
            Delete(portifolio);
        }

        public async Task<PagedList<Portifolio>> GetAllPortifoliosAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var portifilioList = await FindAll(trackChanges).Include(c=>c.Category).ToListAsync();
            return PagedList<Portifolio>.ToPagedList(portifilioList, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<Portifolio> GetPortifolioByIdAsync(Guid portifolioId, bool trackChanges)
        {
            return await FindByCondition(p => p.PortifolioId.Equals(portifolioId), trackChanges).Include(c => c.Category).SingleOrDefaultAsync();
        }

        public async Task<Portifolio> GetPortifolioBySlugNameAsync(string slug, bool trackChanges)
        {

            return await FindByCondition(p => p.Slug.Equals(slug), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdatePortifolioAsync(Portifolio portifolio)
        {
            Update(portifolio);
        }
    }
}

