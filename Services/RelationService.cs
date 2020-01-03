using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;

namespace RelationApp.Services
{
    public class RelationService : IRelationService
    {
        private IRepository _repository;

        public RelationService(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _repository.GetCategories();
        }

        public IEnumerable<Relation> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Relation> OrderByProperty(string property, IEnumerable<Relation> relations) 
        {
            var propertyOfChoice = typeof(Relation).GetProperty(property);
            var orderedRelations = relations
                .OrderBy(relation => 
                (string)propertyOfChoice.GetValue(relation));

            return orderedRelations;
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

        public string GetValidPostalCode(string country, string postalCode)
        {
            var postalCodeFormat = _repository.GetPostalCodeFormat(country);

            if (postalCodeFormat == null)
                return postalCode;

            return ValidateAgainstFormat(postalCodeFormat, postalCode);
        }

        public static string ValidateAgainstFormat(string postalCodeFormat, string postalCode)
        {
            if(string.IsNullOrEmpty(postalCodeFormat))
                return postalCode;

            if (string.IsNullOrEmpty(postalCode))
                return null;

            var result = new StringBuilder();

            for(int formatCursor = 0, codeCursor = 0;
                formatCursor < postalCodeFormat.Length && codeCursor < postalCode.Length;
                formatCursor++, codeCursor++)
            {
                var formatSymbol = postalCodeFormat[formatCursor];
                var currentPostalCharacter = postalCode[codeCursor];

                if (formatSymbol == 'N' && char.IsDigit(currentPostalCharacter))
                {
                    result.Append(currentPostalCharacter);
                }
                else if (formatSymbol == 'N' && char.IsLetter(currentPostalCharacter))
                {
                    formatCursor--;
                }
                else if (formatSymbol == 'l' && char.IsLetter(currentPostalCharacter))
                {
                    result.Append(char.ToLower(currentPostalCharacter));
                }
                else if (formatSymbol == 'L' && char.IsLetter(currentPostalCharacter))
                {
                    result.Append(char.ToUpper(currentPostalCharacter));
                }
                else if (char.IsPunctuation(formatSymbol))
                {
                    result.Append(formatSymbol);
                    codeCursor--;
                }
                else if (char.IsLetter(formatSymbol) && char.IsDigit(currentPostalCharacter))
                {
                    formatCursor--;
                }
                else
                    return postalCode;
            }

            return result.ToString();
        }
    }
}
