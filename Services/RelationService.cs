using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Relation> GetByCategory(string category) 
        {
            return _repository.GetByCategory(category);
        }

        public IEnumerable<Relation> GetFiltered(Func<Relation, bool> predicate)
        {
            return _repository.GetFiltered(predicate);
        }


        public void Add(Relation relation)
        {
            _repository.Add(relation);
        }

        public void Delete(Guid relationId)
        {
            validateId(relationId);
            var relation = _repository.GetById(relationId);
            _repository.Delete(relation);
        }

        public void Update(Relation relation)
        {
            validateId(relation.Id);
            _repository.Update(relation);
        }
        public Relation GetById(Guid relationId)
        {
            return _repository.GetById(relationId);
        }

        private void validateId(Guid id)
        {
            if (_repository.GetById(id) == null)
            {
                throw new KeyNotFoundException($"relation not found, id : {id}");
            }
        }
    }
}
