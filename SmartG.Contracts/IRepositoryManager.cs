using System;
namespace SmartG.Contracts
{
    public interface IRepositoryManager
    {
		Task SaveAsync();
		IPageRepository Page { get; }
		IPostRepository Post { get; }
		ICategoryRepository Category{ get; }
		ICommentRepository Comment{ get; }
	}
}

