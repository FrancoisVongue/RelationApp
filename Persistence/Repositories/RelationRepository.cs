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
        }

        public void Remove(Relation t)
        { 
            _context.Remove(t);
        }

        public void Update(Relation t)
        { 
            _context.Update(t);
        }

        public void Save()
        { 
            _context.SaveChanges();
        }

        public bool Exists(Guid id)
        {
            var result = _context.Find<Relation>(id);
            return result == null ? false : true;
        }
    }
}
