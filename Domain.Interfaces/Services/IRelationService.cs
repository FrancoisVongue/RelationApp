using RelationApp.Domain.Models;
using System;
using System.Collections.Generic;

namespace RelationApp.Domain.Iterfaces
{
    public interface IRelationService
    {        
        public IEnumerable<Relation> GetAll();

        public IEnumerable<Relation> GetOrdered(string property);

        public IEnumerable<Relation> Choose(Func<Relation, bool> predicate);

        public void Add(Relation relation);

        public void Remove(Guid relationId);

        public void Update(Relation relation);

        public void Save();
    }
}
