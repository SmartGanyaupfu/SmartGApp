using System;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

namespace SmartG.Contracts
{
    public interface ICommentRepository
    {
        Task<PagedList<Comment>> GetAllCommentsForPostAsync(CommentParameters commentParameters,int postId, bool trackChanges);
        Task<Comment> GetCommentByIdAsync(int commentId, bool trackChanges);
        void CreateCommentAsync(Comment comment);
        void DeleteCommentAsync(Comment comment);
        void UpdateCommentAsync(Comment  comment);
    }
}

