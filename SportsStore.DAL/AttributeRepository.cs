using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SportsStore.DAL
{
    public class AttributeRepository : IRepository<Attribute>
    {
        private readonly EfDbContext _db;

        public AttributeRepository(EfDbContext db)
        {
            _db = db;
        }

        public void Create(Attribute item)
        {
            _db.Attributes.Add(item);
        }

        public void Delete(int id)
        {
            var attribute = _db.Attributes.Find(id);
            if (attribute != null)
            {
                _db.Attributes.Remove(attribute);
            }
        }

        public IEnumerable<Attribute> FindByCondition(Func<Attribute, bool> condition)
        {
            return _db.Attributes.Where(condition).ToList();
        }

        public IEnumerable<Attribute> GetAll()
        {
            return _db.Attributes;
        }

        public Attribute GetById(int id)
        {
            return _db.Attributes.Find(id);
        }

        public void Update(Attribute item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}