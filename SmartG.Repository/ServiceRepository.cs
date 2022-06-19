using System;
using Microsoft.EntityFrameworkCore;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

namespace SmartG.Repository
{
    public class ServiceRepository : GenericRepositoryBase<OfferedService>, IServiceRepository
    {
        public ServiceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateServiceAsync(OfferedService service)
        {
            Create(service);
        }

        public void DeleteServiceAsync(OfferedService service)
        {
            Delete(service);
        }

        public async Task<OfferedService> GetServiceByIdAsync(Guid serviceId, bool trackChanges)
        {
            return await FindByCondition(s => s.OfferedServiceId.Equals(serviceId), trackChanges).Include(i=>i.Image).Include(b=>b.ContentBlocks).SingleOrDefaultAsync();
        }

        public async Task<OfferedService> GetServiceBySlugAsync(string slug, bool trackChanges)
        {
            return await FindByCondition(s => s.Slug.Equals(slug), trackChanges).Include(i => i.Image).Include(b => b.ContentBlocks).SingleOrDefaultAsync();
        }

        public async Task<PagedList<OfferedService>> GetServicesAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var services = await FindAll(trackChanges).Include(i => i.Image).Include(b => b.ContentBlocks).OrderByDescending(p => p.DateCreated).ToListAsync();

            return PagedList<OfferedService>.ToPagedList(services, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public void UpdateServiceAsync(OfferedService service)
        {
            Update(service);
        }
    }
}

