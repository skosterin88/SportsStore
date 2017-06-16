using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.BLL;
using SportsStore.DAL;

namespace SportsStore.Tests
{
    [TestClass]
    public class ProductServiceTests
    {
        private readonly IUnitOfWork _unitOfWork;

        private IRepository<Product> CreateTestProductsRepository(IList<Product> products)
        {
            var mockProductsRepository = new Mock<IRepository<Product>>();

            mockProductsRepository.Setup(mr => mr.GetAll()).Returns(products);
            mockProductsRepository.Setup(mr => mr.GetById(It.IsAny<int>()))
                .Returns((int id) => products.Single(prod => prod.Id == id));
            mockProductsRepository.Setup(mr => mr.FindByCondition(It.IsAny<Func<Product, bool>>()))
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

            var productsRepository = mockProductsRepository.Object;
            return productsRepository;
        }

        private IRepository<Category> CreateTestCategoriesRepository(IList<Category> categories)
        {
            var mockCategoriesRepository = new Mock<IRepository<Category>>();

            mockCategoriesRepository.Setup(mr => mr.GetAll()).Returns(categories);
            mockCategoriesRepository.Setup(mr => mr.GetById(It.IsAny<int>()))
                .Returns((int id) => categories.Single(catg => catg.Id == id));
            mockCategoriesRepository.Setup(mr => mr.FindByCondition(It.IsAny<Func<Category, bool>>()))
                .Returns((Func<Category, bool> condition) => categories.Where(condition).ToList());
            mockCategoriesRepository.Setup(mr => mr.Create(It.IsAny<Category>())).Callback((Category target) =>
            {
                categories.Add(target);
            });
            mockCategoriesRepository.Setup(mr => mr.Delete(It.IsAny<int>())).Callback((int id) =>
            {
                var category = categories.Single(prod => prod.Id == id);
                categories.Remove(category);
            });

            var categoriesRepository = mockCategoriesRepository.Object;
            return categoriesRepository;
        }

        private IRepository<Order> CreateTestOrdersRepository(IList<Order> orders)
        {
            var mockOrdersRepository = new Mock<IRepository<Order>>();

            mockOrdersRepository.Setup(mr => mr.GetAll()).Returns(orders);
            mockOrdersRepository.Setup(mr => mr.GetById(It.IsAny<int>()))
                .Returns((int id) => orders.Single(catg => catg.Id == id));
            mockOrdersRepository.Setup(mr => mr.FindByCondition(It.IsAny<Func<Order, bool>>()))
                .Returns((Func<Order, bool> condition) => orders.Where(condition).ToList());
            mockOrdersRepository.Setup(mr => mr.Create(It.IsAny<Order>())).Callback((Order target) =>
            {
                orders.Add(target);
            });
            mockOrdersRepository.Setup(mr => mr.Delete(It.IsAny<int>())).Callback((int id) =>
            {
                var order = orders.Single(prod => prod.Id == id);
                orders.Remove(order);
            });

            var ordersRepository = mockOrdersRepository.Object;
            return ordersRepository;
        }

        private IRepository<Customer> createTestCustomersRepository(IList<Customer> customers)
        {
            var mockCustomersRepository = new Mock<IRepository<Customer>>();

            mockCustomersRepository.Setup(mr => mr.GetAll()).Returns(customers);
            mockCustomersRepository.Setup(mr => mr.GetById(It.IsAny<int>()))
                .Returns((int id) => customers.Single(catg => catg.Id == id));
            mockCustomersRepository.Setup(mr => mr.FindByCondition(It.IsAny<Func<Customer, bool>>()))
                .Returns((Func<Customer, bool> condition) => customers.Where(condition).ToList());
            mockCustomersRepository.Setup(mr => mr.Create(It.IsAny<Customer>())).Callback((Customer target) =>
            {
                customers.Add(target);
            });
            mockCustomersRepository.Setup(mr => mr.Delete(It.IsAny<int>())).Callback((int id) =>
            {
                var customer = customers.Single(prod => prod.Id == id);
                customers.Remove(customer);
            });

            var customersRepository = mockCustomersRepository.Object;
            return customersRepository;
        }

        private IUnitOfWork CreateFakeUnitOfWork()
        {
            var product1 = new Product
            {
                Id = 1,
                Name = "Product 1",
                Description = "Product #1",
                Price = 250,
                Sku = "8504890"
            };
            var product2 = new Product
            {
                Id = 2,
                Name = "Product 2",
                Description = "Product #2",
                Price = 300,
                Sku = "8504891"
            };
            var product3 = new Product
            {
                Id = 3,
                Name = "Product 3",
                Description = "Product #3",
                Price = 350,
                Sku = "8504892"
            };
            var product4 = new Product
            {
                Id = 4,
                Name = "Product 4",
                Description = "Product #4",
                Price = 400,
                Sku = "8504893"
            };
            var product5 = new Product
            {
                Id = 5,
                Name = "Product 5",
                Description = "Product #5",
                Price = 450,
                Sku = "8504894"
            };

            var category1 = new Category
            {
                Id = 1,
                Name = "Category 1",
                NumberInCategoryList = 1,
                ParentCategoryId = 0,
                Products = new List<Product> { product1, product2 }
            };
            var category2 = new Category
            {
                Id = 2,
                Name = "Category 2",
                NumberInCategoryList = 2,
                ParentCategoryId = 0,
                Products = new List<Product> { product3, product4 }
            };
            var category3 = new Category
            {
                Id = 3,
                Name = "Category 3",
                NumberInCategoryList = 3,
                ParentCategoryId = 0,
                Products = new List<Product> { product5 }
            };

            product1.Categories = new List<Category> { category1 };
            product2.Categories = new List<Category> { category1 };
            product3.Categories = new List<Category> { category2 };
            product4.Categories = new List<Category> { category2 };
            product5.Categories = new List<Category> { category3 };

            var order1 = new Order
            {
                Id = 1,
                CreationTime = DateTime.Parse("10.06.2017 12:00"),
                TotalSum = product1.Price + product2.Price,
                Products = new List<Product> {product1, product2}
            };
            var order2 = new Order
            {
                Id = 2,
                CreationTime = DateTime.Parse("12.06.2017 15:00"),
                TotalSum = product3.Price + product4.Price + product5.Price,
                Products = new List<Product> { product3, product4, product5 }
            };

            product1.Orders = new List<Order> { order1 };
            product2.Orders = new List<Order> { order1 };
            product3.Orders = new List<Order> { order2 };
            product4.Orders = new List<Order> { order2 };
            product5.Orders = new List<Order> { order2 };

            var customer1 = new Customer
            {
                Id = 1,
                Email = "gwashington@whitehouse.gov",
                Password = "independence",
                Name = "George Washington",
                Orders = new List<Order> { order1 }
            };
            var customer2 = new Customer
            {
                Id = 2,
                Email = "heisenberg@albuquerque.com",
                Password = "meth",
                Name = "Heisenberg",
                Orders = new List<Order> { order2 }
            };

            order1.Customer = customer1;
            order2.Customer = customer2;

            IList<Product> products = new List<Product> {product1, product2, product3, product4, product5};
            IList<Category> categories = new List<Category> { category1, category2, category3 };
            IList<Order> orders = new List<Order> { order1, order2 };
            IList<Customer> customers = new List<Customer> { customer1, customer2 };

            var productsRepository = CreateTestProductsRepository(products);
            var categoriesRepository = CreateTestCategoriesRepository(categories);
            var ordersRepository = CreateTestOrdersRepository(orders);
            var customersRepository = createTestCustomersRepository(customers);

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.Products).Returns(productsRepository);
            mockUnitOfWork.Setup(m => m.Orders).Returns(ordersRepository);
            mockUnitOfWork.Setup(m => m.Categories).Returns(categoriesRepository);
            mockUnitOfWork.Setup(m => m.Customers).Returns(customersRepository);

            var unitOfWork = mockUnitOfWork.Object;
            return unitOfWork;
        }

        public ProductServiceTests()
        {
            _unitOfWork = CreateFakeUnitOfWork();
        }

        [TestMethod]
        public void CanAddNewProduct()
        {
            var newProductDto = new ProductDto
            {
                Id = 6,
                Name = "Product 6",
                CategoryIds = new List<int> {1},
                Description = "Product #6",
                Price = 1000
            };

            IProductService productService = new ProductService(_unitOfWork);
            productService.AddProduct(newProductDto);
            var products = _unitOfWork.Products.GetAll();

            Assert.AreEqual(6, products.Count());
            Assert.AreEqual("Category 1", products.Last().Categories.ElementAt(0).Name);
        }
    }
}