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

        public IEnumerable<Relation> Choose(Func<Relation, bool> predicate)
        {
            return _repository.GetFiltered(predicate);
        }

        public Relation GetOne(Guid relationId)
        {
            validateId(relationId);
            return Choose(relation => relation.Id == relationId).First();
        }

        public void Add(Relation relation)
        {
            _repository.Add(relation);
        }

        public void Remove(Guid relationId)
        {
            validateId(relationId);
            var relation = _repository.GetOne(relationId);
            _repository.Remove(relation);
        }

        public void Update(Relation relation)
        {
            validateId(relation.Id);
            _repository.Update(relation);
        }

        private void validateId(Guid id)
        {
            if (!_repository.Exists(id))
            {
                throw new KeyNotFoundException("relation not found");
            }
        }
    }
}
