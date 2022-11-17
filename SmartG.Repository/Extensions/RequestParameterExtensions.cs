using System;
using System.Reflection;
using SmartG.Entities.Models;

namespace SmartG.Repository.Extensions
{
    public static class RequestParameterExtensions
    {
       

        public static List<T> LikeSearch<T>(this List<T> data,string key, string searchTerm)
        {
            var property = typeof(T).GetProperty(key, BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance);
            //if (property == null)
            if (string.IsNullOrWhiteSpace(searchTerm))
                return data;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return data.Where(d => ((string)property.GetValue(d)).Contains(lowerCaseTerm)).ToList();
        }

        public static IQueryable<Post> FilterPostsByAuthor(this IQueryable<Post>
           post, string author)
        {
            if (string.IsNullOrWhiteSpace(author))
                return post;

            return post.Where(
               p => (p.AuthorId == author));
        }

        public static IQueryable<Post> FilterPostsByCategory(this IQueryable<Post>
     post, int sgCategoryId)
        {
            if (sgCategoryId<1)
                return post;
           return  post.Where(
         p => (p.SgCategoryId == sgCategoryId));
        }
    
    }
 
}

