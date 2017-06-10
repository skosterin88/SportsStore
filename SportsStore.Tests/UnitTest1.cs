using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.DAL;

namespace SportsStore.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private readonly IRepository<Product> _productsRepository;

        public RepositoryTests()
        {
            IList<Product> products = new List<Product>()
            {
                new Product {Id = 1, Name = "Product 1", Price = 250},
                new Product {Id = 2, Name = "Product 2", Price = 200},
                new Product {Id = 3, Name = "Product 3", Price = 300}
            };

            var mockProductsRepository = new Mock<IRepository<Product>>();

            mockProductsRepository.Setup(mr => mr.GetAll()).Returns(products);
            mockProductsRepository.Setup(mr => mr.GetById(It.IsAny<int>()))
                .Returns((int id) => products.Single(prod => prod.Id == id));
            mockProductsRepository.Setup(mr => mr.FindByCondition(It.IsAny<Func<Product,bool>>()))
                .Returns((Func<Product, bool> condition) => products.Where(condition).ToList());
            mockProductsRepository.Setup(mr => mr.Create(It.IsAny<Product>())).Callback((Product target) =>
            {
                products.Add(target);
            });
            mockProductsRepository.Setup(mr => mr.Delete(It.IsAny<int>())).Callback((int id) =>
            {
                var product = products.Single(prod => prod.Id == id);
                products.Remove(product);
            });

            _productsRepository = mockProductsRepository.Object;
        }

        [TestMethod]
        public void CanAddNewProducts()
        {
            var newProduct = new Product{Id = 4, Name = "Product 4", Price = 500 };

            _productsRepository.Create(newProduct);
            var testProduct = _productsRepository.GetById(4);

            Assert.AreEqual("Product 4", testProduct.Name);
        }

        [TestMethod]
        public void CanRemoveProducts()
        {
            int productId = 3;

            _productsRepository.Delete(productId);
            int qProducts = _productsRepository.GetAll().Count();

            Assert.AreEqual(2, qProducts);
        }

        [TestMethod]
        public void CanGetAllProducts()
        {
            var testProducts = _productsRepository.GetAll();

            Assert.IsNotNull(testProducts);
            Assert.AreEqual(3, testProducts.Count());
        }

        [TestMethod]
        public void CanGetProductById()
        {
            var testProduct = _productsRepository.GetById(1);

            Assert.IsNotNull(testProduct);
            Assert.AreEqual("Product 1", testProduct.Name);
        }

        [TestMethod]
        public void CanGetProductByCondition()
        {
            var testProducts = _productsRepository.FindByCondition(prod => prod.Price == 200);

            Assert.IsNotNull(testProducts.ElementAt(0));
            Assert.AreEqual("Product 2", testProducts.ElementAt(0).Name);
        }
    }
}
