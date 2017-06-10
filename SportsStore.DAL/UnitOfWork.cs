﻿using System;

namespace SportsStore.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EfDbContext _db;
        private ProductRepository _products;
        private AttributeRepository _attributes;
        private CategoryRepository _categories;
        private bool _isDisposed;

        public UnitOfWork(string connectionString)
        {
            _db = new EfDbContext(connectionString);
        }

        public IRepository<Attribute> Attributes
        {
            get
            {
                if (_attributes == null)
                {
                    _attributes = new AttributeRepository(_db);
                }
                return _attributes;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new CategoryRepository(_db);
                }
                return _categories;
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new ProductRepository(_db);
                }
                return _products;
            }
        }
        
        public virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}