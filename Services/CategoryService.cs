using Domain.Interfaces.Services;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public void Add(Category relation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> Choose(Func<Category, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid relationId)
        {
            throw new NotImplementedException();
        }
    }
}
