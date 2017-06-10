using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SportsStore.DAL
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly EfDbContext _db;

        public ProductRepository(EfDbContext db)
        {
            _db = db;
        }

        public void Create(Product item)
        {
            _db.Products.Add(item);
        }

        public void Delete(int id)
        {
            var item = _db.Products.Find(id);
            if (item != null)
            {
                _db.Products.Remove(item);
            }
        }

        public IEnumerable<Product> FindByCondition(Func<Product, bool> condition)
        {
            return _db.Products.Where(condition).ToList();
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Products;
        }

        public Product GetById(int id)
        {
            return _db.Products.Find(id);
        }

        public void Update(Product item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}