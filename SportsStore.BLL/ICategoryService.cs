using System;
using System.Collections.Generic;

namespace SportsStore.BLL
{
    public interface ICategoryService : IDisposable
    {
        void AddProductToCategory(ProductDto productDto, CategoryDto categoryDto);
        void AddCategory(CategoryDto categoryDto);
        void AddSubcategory(int parentCategoryId, CategoryDto subcategory);
        CategoryDto GetCategory(int id);
        IEnumerable<CategoryDto> GetAllCategories();
        IEnumerable<CategoryDto> GetSubcategories(int categoryId);
    }
}