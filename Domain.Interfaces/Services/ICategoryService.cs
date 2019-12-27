using System;
using System.Collections.Generic;
using RelationApp.Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        public IEnumerable<Category> GetAll();

        public IEnumerable<Category> Choose(Func<Category, bool> predicate);

        public void Add(Category relation);

        public void Remove(Guid relationId);
    }
}
