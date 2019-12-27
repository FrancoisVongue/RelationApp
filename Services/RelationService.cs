using System;
using System.Collections.Generic;
using System.Linq;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;

namespace RelationApp.Services
{
    public class RelationService : IRelationService
    {
        private IRepository<Relation> repository;

        public RelationService(IRepository<Relation> repo)
        {
            repository = repo;
        }

        public IEnumerable<Relation> GetAll()
        {
            return repository.GetAll();
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
            return GetAll().Where(predicate);
        }

        public void Add(Relation relation)
        {
            // TODO. Move it to Automapper.
            // Map from CreateRealtionViewModel -> to Relation
            relation.Id = new Guid();
            relation.CreatedAt = DateTime.Now;
            relation.IsDisabled = false;
            relation.IsTemporary = false;
            relation.IsMe = false;
            relation.PaymentViaAutomaticDebit = false;
            relation.InvoiceDateGenerationOptions = 0;
            relation.InvoiceGroupByOptions = 0;
            relation.CreatedBy = "User";

            repository.Add(relation);
            Save();
        }

        public void Remove(Guid relationId)
        {
            if(repository.Exists(relationId))
            {
                var relation = Choose(relation => relation.Id == relationId).First();
                repository.Remove(relation);
                Save();
            }
        }

        public void Update(Relation relation)
        {
            if (repository.Exists(relation.Id))
            {
                repository.Update(relation);
                Save();
            }
        }

        public void Save()
        {
            repository.Save();
        }
    }
}
