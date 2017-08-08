using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SportsStore.BLL;
using SportsStore.Web.Models;

namespace SportsStore.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Category
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDto, CategoryViewModel>();
            });
            var mapper = config.CreateMapper();

            var topLevelCategoryDtos = _categoryService.GetAllTopLevelCategories();
            var topLevelCategoryViewModels =
                topLevelCategoryDtos.Select(cdto => mapper.Map<CategoryDto, CategoryViewModel>(cdto));

            return View(topLevelCategoryViewModels);
        }
    }
}