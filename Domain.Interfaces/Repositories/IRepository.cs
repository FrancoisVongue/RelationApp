using System.Collections.Generic;
using System;
using RelationApp.Domain.Models;

namespace RelationApp.Domain.Iterfaces
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetFiltered(Func<TEntity, bool> predicate);

        IEnumerable<TEntity> GetByCategory(string categoryName);

        TEntity GetById(Guid id);

        void Add(TEntity t);

        void Delete(TEntity t);

        void Update(TEntity t);

        bool Exists(Guid id);
    }
}
