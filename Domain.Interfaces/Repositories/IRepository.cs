using System.Collections.Generic;
using System;
using RelationApp.Domain.Models;

namespace RelationApp.Domain.Iterfaces
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetFiltered(Func<TEntity, bool> predicate);

        TEntity GetOne(Guid id);

        void Add(TEntity t);

        void Remove(TEntity t);

        void Update(TEntity t);

        bool Exists(Guid id);
    }
}
