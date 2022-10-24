﻿using System;
using Microsoft.EntityFrameworkCore;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

using SmartG.Repository.Extensions;

namespace SmartG.Repository
{
    public class PostRepository : GenericRepositoryBase<Post>, IPostRepository
    {
        public PostRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
        }

        public void CreatePostAsync(Post post)
        {
            Create(post);
        }

        public void DeletePostAsync(Post post)
        {
            Delete(post);
        }

        public async Task<PagedList<Post>> GetAllPostsAsync(PostParameters postParameters, bool trackChanges)
        {
            var posts = await FindAll(trackChanges).Search(postParameters.SearchTerm).Include(i => i.Image).Include(c => c.Category).Include(g => g.Gallery).ThenInclude(i => i.Images)
                .OrderByDescending(p => p.DateCreated).ToListAsync();
            return PagedList<Post>.ToPagedList(posts, postParameters.PageNumber, postParameters.PageSize);
        }

        public async Task<Post> GetPostByIdAsync(Guid postId, bool trackChanges)
        {
            return await FindByCondition(p=>p.PostId.Equals(postId),trackChanges).Include(i => i.Image).Include(c=>c.Category).Include(b => b.ContentBlocks).Include(g => g.Gallery).ThenInclude(i => i.Images)
                .SingleOrDefaultAsync();
        }

        public async Task<Post> GetPostBySlugNameAsync(string slug, bool trackChanges)
        {
            return await FindByCondition(p => p.Slug.Equals(slug), trackChanges).Include(i => i.Image).Include(b => b.ContentBlocks).Include(g => g.Gallery).ThenInclude(i => i.Images)
                .SingleOrDefaultAsync();
        }

        public void UpdatePostAsync(Post post)
        {
            Update(post);
        }
    }
}

