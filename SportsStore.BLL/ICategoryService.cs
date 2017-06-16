using System;
using System.Collections.Generic;

namespace SportsStore.BLL
{
    public interface ICategoryService : IDisposable
    {
        void AddCategory(CategoryDto categoryDto);
        void AddSubcategory(int parentCategoryId, CategoryDto subcategory);
        CategoryDto GetCategory(int id);
        IEnumerable<CategoryDto> GetAllTopLevelCategories();
        IEnumerable<CategoryDto> GetSubcategories(int parentCategoryId);
    }
}