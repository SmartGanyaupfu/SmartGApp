using System;
using SmartG.Entities.Models;

namespace SmartG.Repository.Extensions
{
    public static class PageRepo
    {
        public static IQueryable<Page> Search(this IQueryable<Page> posts, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return posts;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return posts.Where(e => e.Title.ToLower().Contains(lowerCaseTerm));
        }
    }
}

