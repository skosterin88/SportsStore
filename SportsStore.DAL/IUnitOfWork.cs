using System;

namespace SportsStore.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        IRepository<Attribute> Attributes { get; }
        void Save();
    }
}