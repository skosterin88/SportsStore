using System;
using System.Collections.Generic;
using System.Linq;
using SportsStore.DAL;
using AutoMapper;

namespace SportsStore.BLL
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddProduct(ProductDto productDto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDto, Product>()
                    .ForMember(prod => prod.Categories,
                        src =>
                            src.MapFrom(
                                pdto =>
                                    _unitOfWork.Categories.FindByCondition(catg => pdto.CategoryIds.Contains(catg.Id))));
            });
            var mapper = config.CreateMapper();
            var product = mapper.Map<ProductDto, Product>(productDto);
            _unitOfWork.Products.Create(product);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public ProductDto GetProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}