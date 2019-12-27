using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;
using System;
using System.Linq;

namespace RelationApp.Persistence.Repositories
{
    public class RelationRepository : IRepository<Relation>
    {
        private DbContext context;
        private IEnumerable<Relation> relations;

        public RelationRepository(DbContext context)
        { 
            this.context = context;
            relations = context.Set<Relation>();
        }

        public IEnumerable<Relation> GetAll()
        {
            return relations;
        }

        public IEnumerable<Relation> Choose(Func<Relation, bool> predicate)
        {
            return relations.Where(predicate);
        }

        public Relation GetOne(Func<Relation, bool> predicate)
        {
            return Choose(predicate).FirstOrDefault();
        }

        public void Add(Relation t)
        { 
            context.Add(t);
        }

        public void Remove(Relation t)
        { 
            context.Remove(t);
        }

        public void Update(Relation t)
        { 
            context.Update(t);
        }

        public void Save()
        { 
            context.SaveChanges();
        }

        public bool Exists(Guid id)
        {
            return GetOne(relation => relation.Id == id) != null;
        }
    }
}
