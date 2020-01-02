using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;

namespace RelationApp.Services
{
    public class RelationService : IRelationService
    {
        private IRepository<Relation> _repository;

        public RelationService(IRepository<Relation> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Relation> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Relation> GetOrdered(string property) 
        {
            var relations = GetAll();

            if (string.IsNullOrEmpty(property))
            {
                return relations;
            }

            var defaultProperty = typeof(Relation).GetProperty(nameof(Relation.Name));
            var propertyOfChoice = typeof(Relation).GetProperty(property) ?? defaultProperty;

            return relations.OrderBy(relation => (string)propertyOfChoice.GetValue(relation));
        }

        public IEnumerable<Relation> GetByCategory(string categoryName) 
        {
            return _repository.GetByCategory(categoryName);
        }

        public IEnumerable<Relation> GetFiltered(Expression<Func<Relation, bool>> expression)
        {
            return _repository.GetFiltered(expression.Compile());
        }

        public void Add(Relation relation)
        {
            _repository.Add(relation);
        }

        public void Delete(Guid relationId)
        {
            var relation = GetById(relationId);

            _repository.Delete(relation);
        }

        public void Update(Relation changedRelation)
        {
            GetById(changedRelation.Id);

            _repository.Update(changedRelation);
        }
        public Relation GetById(Guid relationId)
        {
            var relation = _repository.GetById(relationId);

            if (relation == null)
            {
                throw new KeyNotFoundException($"Relation with id '{relationId}' is not found.");
            }

            return relation;
        }
    }
}
