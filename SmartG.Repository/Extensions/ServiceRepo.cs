using System;
using SmartG.Entities.Models;

namespace SmartG.Repository.Extensions
{
    public static class ServiceRepo
    {
        public static IQueryable<OfferedService> Search(this IQueryable<OfferedService> posts, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return posts;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return posts.Where(e => e.Title.ToLower().Contains(lowerCaseTerm));
        }
    }
}

