using System;
using Microsoft.EntityFrameworkCore;
using SmartG.Contracts;
using SmartG.Entities.Models;

namespace SmartG.Repository
{
    public class WidgetRepository : GenericRepositoryBase<Widget>, IWidgetRepository
    {
        public WidgetRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateWidgetAsync(Widget widget)
        {
            Create(widget);
        }

        public void DeleteWidgetAsync(Widget widget)
        {
            Delete(widget);
        }

        public async Task<Widget> GetWidgetByIdAsync(int widgetId, bool trackChanges)
        {
            return await FindByCondition(w => w.WidgetId.Equals(widgetId), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<Widget> GetWidgetsAsync(bool trackChanges)
        {
            var widget = await FindAll(trackChanges).ToListAsync();
            var myWidget = widget.FirstOrDefault();

            return myWidget;
        }

        public void UpdateWidgetAsync(Widget widget)
        {
            Update(widget);
        }
    }
}

