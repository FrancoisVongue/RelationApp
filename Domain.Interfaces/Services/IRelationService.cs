using RelationApp.Domain.Models;
using System;
using System.Collections.Generic;

namespace RelationApp.Domain.Iterfaces
{
    public interface IRelationService
    {        
        public IEnumerable<Relation> GetAll();

        public Relation GetById(Guid relationId);

        public IEnumerable<Relation> GetOrdered(string property);

        public IEnumerable<Relation> GetByCategory(string category);

        public IEnumerable<Relation> GetFiltered(Func<Relation, bool> predicate);

        public void Add(Relation relation);

        public void Delete(Guid relationId);

        public void Update(Relation relation);
    }
}
