using System;
using SmartG.Entities.Models;

namespace SmartG.Contracts
{
    public interface IWidgetRepository
    {
        
        Task<Widget> GetWidgetsAsync(bool trackChanges);
        Task<Widget> GetWidgetByIdAsync(int widgetId, bool trackChanges);
        void CreateWidgetAsync(Widget widget);
        void DeleteWidgetAsync(Widget widget);
        void UpdateWidgetAsync(Widget widget);
    }
}

