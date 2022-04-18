using System;
using SmartG.Contracts;

namespace SmartG.Repository
{
    public class RepositoryManager:IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IPageRepository> _pageRepository;
        private readonly Lazy<IPostRepository> _postRepository;

        private readonly Lazy<ICommentRepository> _commentRepository;

        private readonly Lazy<ICategoryRepository> _categoryRepository;

        public RepositoryManager( RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _pageRepository = new Lazy<IPageRepository>(() => new PageRepository(repositoryContext));
            _postRepository = new Lazy<IPostRepository>(() => new PostRepository(repositoryContext));
            _commentRepository = new Lazy<ICommentRepository>(() => new CommentRepository(repositoryContext));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(repositoryContext));

        }

        public IPageRepository Page => _pageRepository.Value;

        public IPostRepository Post => _postRepository.Value;

        public ICategoryRepository Category => _categoryRepository.Value;

        public ICommentRepository Comment => _commentRepository.Value;

        public async Task SaveAsync()
        {
           await _repositoryContext.SaveChangesAsync();
        }
    }
}

