using System.Collections.Generic;
using System;

namespace RelationApp.Domain.Iterfaces
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetOne(Guid id);

        void Add(TEntity t);

        void Remove(TEntity t);

        void Update(TEntity t);

        bool Exists(Guid id);
    }
}
