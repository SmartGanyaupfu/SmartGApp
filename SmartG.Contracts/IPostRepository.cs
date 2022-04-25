using System;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

namespace SmartG.Contracts
{
    public interface IPostRepository
    {
        Task<PagedList<Post>> GetAllPostsAsync(PostParameters postParameters, bool trackChanges);
        Task<Post> GetPostByIdAsync(int postId, bool trackChanges);
        Task<Post> GetPostBySlugNameAsync(string slug, bool trackChanges);
        void CreatePostAsync(Post post);
        void DeletePostAsync(Post post);
        void UpdatePostAsync(Post post);
    }
}

