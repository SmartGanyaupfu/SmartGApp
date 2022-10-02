using System;
using SmartG.Contracts;

namespace SmartG.Repository
{
    public class RepositoryManager:IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IPageRepository> _pageRepository;
        private readonly Lazy<IPostRepository> _postRepository;
        private readonly Lazy<IPortfolioRepository> _portfolioRepository;

        private readonly Lazy<IWidgetRepository> _widgetRepository;

        private readonly Lazy<ICommentRepository> _commentRepository;

        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IImageRepository> _imageRepository;
        private readonly Lazy<IContentBlockRepository> _contentBlockRepository;
        private readonly Lazy<IServiceRepository> _serviceRepository;
        private readonly Lazy<IGalleryRepository> _galleryRepository;

        public RepositoryManager( RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _pageRepository = new Lazy<IPageRepository>(() => new PageRepository(repositoryContext));
            _postRepository = new Lazy<IPostRepository>(() => new PostRepository(repositoryContext));
            _commentRepository = new Lazy<ICommentRepository>(() => new CommentRepository(repositoryContext));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(repositoryContext));
            _portfolioRepository = new Lazy<IPortfolioRepository>(() => new PortfolioRepository(repositoryContext));
            _imageRepository = new Lazy<IImageRepository>(() => new ImageRepository(repositoryContext));
            _contentBlockRepository = new Lazy<IContentBlockRepository>(() => new ContentBlockRepository(repositoryContext));
            _serviceRepository = new Lazy<IServiceRepository>(() => new ServiceRepository(repositoryContext));
            _widgetRepository = new Lazy<IWidgetRepository>(() => new WidgetRepository(repositoryContext));
            _galleryRepository = new Lazy<IGalleryRepository>(() => new GalleryRepository(repositoryContext));

        }

        public IPageRepository Page => _pageRepository.Value;

        public IPostRepository Post => _postRepository.Value;

        public ICategoryRepository Category => _categoryRepository.Value;

        public ICommentRepository Comment => _commentRepository.Value;

        public IPortfolioRepository Portfolio => _portfolioRepository.Value;

        public IImageRepository Image => _imageRepository.Value;

        public IContentBlockRepository ContentBlock => _contentBlockRepository.Value;

        public IServiceRepository Service => _serviceRepository.Value;

        public IWidgetRepository Widget => _widgetRepository.Value;

        public IGalleryRepository Gallery => _galleryRepository.Value;

        public async Task SaveAsync()
        {
           await _repositoryContext.SaveChangesAsync();
        }
    }
}

