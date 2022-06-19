using System;
using Microsoft.EntityFrameworkCore;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

namespace SmartG.Repository
{
    public class PortfolioRepository:GenericRepositoryBase<Portfolio>,IPortfolioRepository
    {
        public PortfolioRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
        }

        public void CreatePortfolioAsync(Portfolio portfolio)
        {
            Create(portfolio);
        }

        public void DeletePortfolioAsync(Portfolio portfolio)
        {
            Delete(portfolio);
        }

        public async Task<PagedList<Portfolio>> GetAllPortfoliosAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var portfolioList = await FindAll(trackChanges).Include(i => i.Image).Include(c=>c.Category).OrderByDescending(p => p.DateCreated).ToListAsync();
            return PagedList<Portfolio>.ToPagedList(portfolioList, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<Portfolio> GetPortfolioByIdAsync(Guid portfolioId, bool trackChanges)
        {
            return await FindByCondition(p => p.PortfolioId.Equals(portfolioId), trackChanges).Include(i=>i.Image).Include(c => c.Category).Include(b => b.ContentBlocks).SingleOrDefaultAsync();
        }

        public async Task<Portfolio> GetPortfolioBySlugNameAsync(string slug, bool trackChanges)
        {

            return await FindByCondition(p => p.Slug.Equals(slug), trackChanges).Include(i => i.Image).Include(b => b.ContentBlocks).SingleOrDefaultAsync();
        }

        public void UpdatePortfolioAsync(Portfolio portfolio)
        {
            Update(portfolio);
        }
    }
}

