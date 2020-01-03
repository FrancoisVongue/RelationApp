using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;
using RelationApp.Persistence.Contexts;
using System;
using System.Linq;

namespace RelationApp.Persistence.Repositories
{
    public class RelationRepository : IRepository
    {
        private DbContext _context;

        private IEnumerable<Relation> _relations;

        public RelationRepository(RelationAppContext context)
        { 
            _context = context;
            _relations = context.Set<Relation>();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Set<Category>().ToArray();
        }

        public IEnumerable<Relation> GetAll()
        {
            return _relations.Where(relation => !relation.IsDisabled).ToList();
        }

        public IEnumerable<Relation> GetFiltered(Func<Relation, bool> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IEnumerable<Relation> GetByCategory(string categoryName)
        {
            Category category = _context.Set<Category>()
                .First(cat => cat.Name == categoryName);

            if (category == null)
                throw new KeyNotFoundException("There is no such a category!");

            var relationsIds = _context.Set<RelationCategory>()
                .Where(rc => rc.CategoryId == category.Id)
                .Select(rc => rc.RelationId).ToList();

            var relations = GetAll().Where(relation =>
                relationsIds.Contains(relation.Id))
                .ToList();

            return relations;
        }

        public string GetPostalCodeFormat(string countryName)
        {
            var countries = _context.Set<Country>();
            var country = countries.First(country => country.Name == countryName);
            return country.PostalCodeFormat;
        }

        public Relation GetById(Guid id)
        {
            return _context.Find<Relation>(id);
        }

        public void Add(Relation relation)
        {
            SetDefaultValues(relation);
            _context.Add(relation);    
            save();
        }

        public void Delete(Relation relation)
        {
            relation.IsDisabled = true;
            save();
        }

        public void Update(Relation updatedRelation)
        {
            var existingRelation = GetById(updatedRelation.Id);
            SetNewValues(updatedRelation, existingRelation);
            _context.Update(existingRelation);
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

        private void SetDefaultValues(Relation r)
        {
            r.IsDisabled = false;
            r.CreatedAt = DateTime.Now;
            r.IsTemporary = false;
            r.IsMe = false;
            r.PaymentViaAutomaticDebit = false;
            r.InvoiceDateGenerationOptions = 0;
            r.InvoiceGroupByOptions = 0;
            r.CreatedBy = "User";
        }

        private void SetNewValues(Relation src, Relation dest) 
        {
            dest.Name = src.Name;
            dest.FullName = src.FullName;
            dest.TelephoneNumber = src.TelephoneNumber;
            dest.EmailAddress = src.EmailAddress;
            dest.DefaultCountry = src.DefaultCountry;
            dest.DefaultCity = src.DefaultCity;
            dest.DefaultStreet = src.DefaultStreet;
            dest.DefaultPostalCode = src.DefaultPostalCode;
        }
    }
}
