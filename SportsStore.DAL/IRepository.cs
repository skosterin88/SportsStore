using System;
using System.Collections.Generic;

namespace SportsStore.DAL
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> FindByCondition(Func<T, bool> condition);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}