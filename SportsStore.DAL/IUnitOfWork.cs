using System;

namespace SportsStore.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get;  }
        IRepository<Category> Categories { get; }
        IRepository<Customer> Customers { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }
}