using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;
using System;

namespace RelationApp.Persistence.Repositories
{
    public class RelationRepository : IRepository<Relation>
    {
        private DbContext _context;

        private IEnumerable<Relation> _relations;

        public RelationRepository(DbContext context)
        { 
            _context = context;
            _relations = context.Set<Relation>();
        }

        public IEnumerable<Relation> GetAll()
        {
            return _relations;
        }

        public void Add(Relation t)
        { 
            _context.Add(t);
            save();
        }

        public void Remove(Relation t)
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
