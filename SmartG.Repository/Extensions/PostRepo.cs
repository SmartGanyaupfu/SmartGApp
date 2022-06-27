using System;
using SmartG.Entities.Models;

namespace SmartG.Repository.Extensions
{
    public static class PostRepo
    {
        public static IQueryable<Post> Search(this IQueryable<Post> posts, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return posts;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return posts.Where(e => e.Title.ToLower().Contains(lowerCaseTerm));
        }
    }
}

