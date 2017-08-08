using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using AutoMapper;
using SportsStore.BLL;
using SportsStore.Web.Models;

namespace SportsStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;

        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public MvcHtmlString GetCategoryHtml(CategoryViewModel category)
        {
            var categoryHtmlBuilder = new StringBuilder();

            categoryHtmlBuilder.Append("<li>");
            categoryHtmlBuilder.Append(category.Name);
            categoryHtmlBuilder.Append("</li>");

            if (category.Subcategories.Any())
            {
                categoryHtmlBuilder.Append("<ul>");
                foreach (var subcat in category.Subcategories)
                {
                    categoryHtmlBuilder.Append(GetCategoryHtml(subcat));
                }
                categoryHtmlBuilder.Append("</ul>");
            }
            else
            {
                return new MvcHtmlString(categoryHtmlBuilder.ToString());
            }

            return new MvcHtmlString(categoryHtmlBuilder.ToString());
        }
        // GET: Home
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDto, CategoryViewModel>();
            });

            var mapper = config.CreateMapper();

            var topLevelCategoryDtos = _categoryService.GetAllTopLevelCategories();
            var topLevelCategories = topLevelCategoryDtos.Select(cdto => mapper.Map<CategoryDto, CategoryViewModel>(cdto)).ToArray();

            foreach (var topCatg in topLevelCategories)
            {
                topCatg.HtmlView = GetCategoryHtml(topCatg);
            }

            return View(topLevelCategories);
        }
    }
}