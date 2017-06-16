using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SportsStore.DAL;

namespace SportsStore.BLL
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            var mapperFactory = new MapperFactory(unitOfWork);
            _mapper = mapperFactory.CreateMapper();
        }

        public void AddCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<CategoryDto, Category>(categoryDto);
            _unitOfWork.Categories.Create(category);
        }
        
        public void AddSubcategory(int parentCategoryId, CategoryDto subcategoryDto)
        {
            var subcategory = _mapper.Map<CategoryDto, Category>(subcategoryDto);
            subcategory.ParentCategoryId = parentCategoryId;
            _unitOfWork.Categories.Create(subcategory);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public IEnumerable<CategoryDto> GetAllTopLevelCategories()
        {
            var topLevelCategories = _unitOfWork.Categories.FindByCondition(catg => catg.ParentCategoryId == 0);
            var topLevelCategoryDtos = topLevelCategories.Select(catg => _mapper.Map<Category, CategoryDto>(catg));
            
            return topLevelCategoryDtos;
        }

        public CategoryDto GetCategory(int id)
        {
            var category = _unitOfWork.Categories.GetById(id);
            var categoryDto = _mapper.Map<Category, CategoryDto>(category);
            return categoryDto;
        }

        public IEnumerable<CategoryDto> GetSubcategories(int parentCategoryId)
        {
            var subcategories = _unitOfWork.Categories.FindByCondition(catg => catg.ParentCategoryId == parentCategoryId);
            var subcategoryDtos = subcategories.Select(catg => _mapper.Map<Category, CategoryDto>(catg));
            return subcategoryDtos;
        }
    }
}