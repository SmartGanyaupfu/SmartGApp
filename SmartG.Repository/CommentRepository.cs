using System;
using Microsoft.EntityFrameworkCore;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

namespace SmartG.Repository
{
    public class CommentRepository : GenericRepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
        }

        public void CreateCommentAsync(Comment comment)
        {
            Create(comment);
        }

        public void DeleteCommentAsync(Comment comment)
        {
            Delete(comment);
        }

        public async Task<PagedList<Comment>> GetAllCommentsForPostAsync(CommentParameters commentParameters, Guid postId,string postType, bool trackChanges)
        {
            if (postType.Equals(PostTypeEnum.portifolio.ToString()))
            {
                var comments = await FindByCondition(c => c.PortifolioId.Equals(postId) && c.Approved, trackChanges).ToListAsync();
                return PagedList<Comment>.ToPagedList(comments, commentParameters.PageNumber, commentParameters.PageSize);
            }
            else 
            {
                var comments = await FindByCondition(c => c.PostId.Equals(postId) && c.Approved, trackChanges).ToListAsync();
                return PagedList<Comment>.ToPagedList(comments, commentParameters.PageNumber, commentParameters.PageSize);
            }
           
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId, bool trackChanges)
        {
            return await FindByCondition(c => c.CommentId.Equals(commentId), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateCommentAsync(Comment comment)
        {
            Update(comment);
        }
    }
}

