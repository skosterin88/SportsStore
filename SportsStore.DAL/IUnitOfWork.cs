using System;

namespace SportsStore.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; set; }
        IRepository<Category> Categories { get; set; }
        IRepository<Customer> Customers { get; set; }
        IRepository<Order> Orders { get; set; }
        void Save();
    }
}