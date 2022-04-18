using System;
using SmartG.Entities.Models;
using SmartG.Shared.RequestFeatures;

namespace SmartG.Contracts
{
    public interface ICategoryRepository
    {
        Task<PagedList<Category>> GetAllCategoriesAsync(CategoryParameters categoryParameters, bool trackChanges);
        Task<Category> GetCategoryByIdAsync(int categoryId, bool trackChanges);
        void CreateCategoryAsync(Category category);
        void DeleteCategoryAsync(Category category);
        void UpdatePageAsync(Category category);
    }
}

