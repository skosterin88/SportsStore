using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SportsStore.DAL
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly EfDbContext _db;

        public CategoryRepository(EfDbContext db)
        {
            _db = db;
        }

        public void Create(Category item)
        {
            _db.Categories.Add(item);
        }

        public void Delete(int id)
        {
            var category = _db.Categories.Find(id);
            if (category != null)
            {
                _db.Categories.Remove(category);
            }
        }

        public IEnumerable<Category> FindByCondition(Func<Category, bool> condition)
        {
            return _db.Categories.Where(condition).ToList();
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Categories;
        }

        public Category GetById(int id)
        {
            return _db.Categories.Find(id);
        }

        public void Update(Category item)
        {
            _db.Entry(item).State = EntityState.Modified;

        }
    }
}