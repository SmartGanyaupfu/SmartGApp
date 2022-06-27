using System;
using SmartG.Entities.Models;

namespace SmartG.Repository.Extensions
{
    public static class PortfolioRepo
    {
        public static IQueryable<Portfolio> Search(this IQueryable<Portfolio> posts, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return posts;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return posts.Where(e => e.Title.ToLower().Contains(lowerCaseTerm));
        }
    }
}

