using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SportsStore.DAL;

namespace SportsStore.BLL
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            var mapperFactory = new MapperFactory(unitOfWork);
            _mapper = mapperFactory.CreateMapper();
        }
        
        public void AddProduct(ProductDto productDto)
        {
            var product = _mapper.Map<ProductDto, Product>(productDto);
            _unitOfWork.Products.Create(product);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = _unitOfWork.Products.GetAll();
            var productDtos = products.Select(product => _mapper.Map<Product, ProductDto>(product));

            return productDtos;
        }

        public ProductDto GetProduct(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            var productDto = _mapper.Map<Product, ProductDto>(product);

            return productDto;
        }
    }
}