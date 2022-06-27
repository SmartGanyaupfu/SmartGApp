using System;
namespace SmartG.Shared.RequestFeatures
{
    public class PageParameters:RequestParameters
    {
        public PageParameters()
        {
        }
        public string? SearchTerm { get; set; }
    }
}

