using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;
using RelationApp.Persistence.Contexts;
using System;
using System.Linq;

namespace RelationApp.Persistence.Repositories
{
    public class RelationRepository : IRepository<Relation>
    {
        private DbContext _context;

        private IEnumerable<Relation> _relations;

        public RelationRepository(RelationAppContext context)
        { 
            _context = context;
            _relations = context.Set<Relation>();
        }

        public IEnumerable<Relation> GetAll()
        {
            return _relations;
        }

        public IEnumerable<Relation> GetFiltered(Func<Relation, bool> predicate)
        {
            return _relations.Where(predicate);
        }

        public IEnumerable<Relation> GetByCategory(string categoryName)
        {
            Category category = _context.Set<Category>()
                .Where(cat => cat.Name == categoryName).FirstOrDefault();
            var relationsCategory = _context.Set<RelationCategory>()
                .Where(rc => rc.CategoryId == category.Id);
            return _relations
                .Where(relation => relationsCategory
                .Select(rc => rc.RelationId)
                .Contains(relation.Id));
        }

        public Relation GetById(Guid id)
        {
            return _context.Find<Relation>(id);
        }

        public void Add(Relation t)
        { 
            _context.Add(t);
            save();
        }

        public void Delete(Relation t)
        { 
            _context.Remove(t);
            save();
        }

        public void Update(Relation t)
        { 
            _context.Update(t);
            save();
        }

        public bool Exists(Guid id)
        {
            var result = _context.Find<Relation>(id);
            return result == null ? false : true;
        }

        private void save()
        { 
            _context.SaveChanges();
        }
    }
}
