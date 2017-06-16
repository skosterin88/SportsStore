using System.Linq;
using AutoMapper;
using SportsStore.DAL;

namespace SportsStore.BLL
{
    public class MapperFactory
    {
        private readonly IUnitOfWork _unitOfWork;

        public MapperFactory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDto, Product>()
                    .ForMember(prod => prod.Categories,
                        src =>
                            src.MapFrom(
                                pdto =>
                                    _unitOfWork.Categories.FindByCondition(catg => pdto.CategoryIds.Contains(catg.Id))));
                cfg.CreateMap<Product, ProductDto>()
                    .ForMember(pdto => pdto.CategoryIds,
                        src =>
                            src.MapFrom(
                                prod =>
                                    _unitOfWork.Products.GetById(prod.Id).Categories.Select(catg => catg.Id)));
                cfg.CreateMap<CategoryDto, Category>()
                    .ForMember(catg => catg.Products,
                        src =>
                            src.MapFrom(
                                cdto => _unitOfWork.Products.FindByCondition(prod => cdto.ProductIds.Contains(prod.Id))));
                cfg.CreateMap<Category, CategoryDto>()
                    .ForMember(cdto => cdto.ProductIds,
                        src =>
                            src.MapFrom(catg => _unitOfWork.Categories.GetById(catg.Id).Products.Select(prod => prod.Id)));
            });

            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}