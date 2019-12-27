using System.Collections.Generic;
using System;

namespace RelationApp.Domain.Iterfaces
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Choose(Func<TEntity, bool> predicate);

        TEntity GetOne(Func<TEntity, bool> predicate);

        void Add(TEntity t);

        void Remove(TEntity t);

        void Update(TEntity t);

        void Save();

        bool Exists(Guid id);
    }
}
