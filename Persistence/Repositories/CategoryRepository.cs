using Microsoft.EntityFrameworkCore;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;
using RelationApp.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Repositories
{
    class CategoryRepository : IRepository<Category>
    {
        private DbContext _context;

        private IEnumerable<Category> _categories;

        public CategoryRepository(RelationAppContext context)
        {
            _context = context;
            _categories = context.Set<Category>();
        }

        public IEnumerable<Category> GetAll()
        {
            return _categories;
        }

        public IEnumerable<Category> GetFiltered(Func<Category, bool> predicate)
        {
            return _categories.Where(predicate);
        }

        public Category GetOne(Guid id)
        {
            return _context.Find<Category>(id);
        }

        public void Add(Category t)
        {
            _context.Add(t);
            save();
        }

        public void Remove(Category t)
        {
            _context.Remove(t);
            save();
        }

        public void Update(Category t)
        {
            _context.Update(t);
            save();
        }

        public bool Exists(Guid id)
        {
            var result = _context.Find<Category>(id);
            return result == null ? false : true;
        }

        private void save()
        {
            _context.SaveChanges();
        }
    }
}
