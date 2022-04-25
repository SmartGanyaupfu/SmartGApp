using System;
using Microsoft.EntityFrameworkCore;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

namespace SmartG.Repository
{
    public class CategoryRepository : GenericRepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
        }

        public void CreateCategoryAsync(Category category)
        {
            Create(category);
        }

        public void DeleteCategoryAsync(Category category)
        {
            Delete(category);
        }

        public async Task<PagedList<Category>> GetAllCategoriesAsync(CategoryParameters categoryParameters, bool trackChanges)
        {
            var categories = await FindAll(trackChanges).ToListAsync();
            return  PagedList<Category>.ToPagedList(categories, categoryParameters.PageNumber, categoryParameters.PageSize);
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId, bool trackChanges)
        {
            return await FindByCondition(c => c.CategoryId.Equals(categoryId),trackChanges).SingleOrDefaultAsync();
        }

        public Task<Category> GetCategoryBySlugAsync(string slug, bool trackChanges)
        {
            return FindByCondition(c => c.Slug.Equals(slug), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdatePageAsync(Category category)
        {
            Update(category);
        }
    }
}

