using System;
using System.Reflection;

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
    }
}

