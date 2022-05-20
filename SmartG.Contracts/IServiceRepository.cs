using System;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

namespace SmartG.Contracts
{
    public interface IServiceRepository
    {
        Task<PagedList<OfferedService>> GetServicesAsync(RequestParameters requestParameters, bool trackChanges);
        Task<OfferedService> GetServiceByIdAsync(Guid serviceId, bool trackChanges);
        Task<OfferedService> GetServiceBySlugAsync(string slug, bool trackChanges);
        void CreateServiceAsync(OfferedService service);
        void DeleteServiceAsync(OfferedService service);
        void UpdateServiceAsync(OfferedService service);
    }
}

