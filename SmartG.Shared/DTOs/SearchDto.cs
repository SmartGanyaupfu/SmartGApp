using System;
namespace SmartG.Shared.DTOs
{
    public class SearchDto
    {
        public ICollection<PageDto> Pages { get; set; }
        public ICollection<PostDto> Posts { get; set; }
        public ICollection<ServiceDto> Services { get; set; }
        public ICollection<PortfolioDto> Portfolios { get; set; }
    }
}

