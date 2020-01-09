using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;
using System.Globalization;

namespace RelationApp.Services
{
    public class RelationService : IRelationService
    {
        // todo : category filtration fix
        private IRepository _repository;

        public RelationService(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<string> GetCategories()
        {
            return _repository.GetCategories().Select(c => c.Name).ToList();
        }

        public IEnumerable<Relation> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Relation> GetRelations(ref int page, int rowsPerPage, string sortfield, string category)
        {
            var amountOfPages = CountPages(rowsPerPage, category);

            if (page > amountOfPages)
                page = amountOfPages;
            if (page < 1)
                page = 1;

            var relations = string.IsNullOrWhiteSpace(category) ?
                _repository.GetAll() :
                GetByCategory(category);

            relations = OrderByProperty(sortfield, relations)
                .Skip( (page - 1) * rowsPerPage )
                .Take(rowsPerPage)
                .ToList();
            return relations;
        }

        public int CountPages(int rowsPerPage, string category)
        {
            if (rowsPerPage < 1) throw new DivideByZeroException("cant divide by zero");
            var amountOfPages = (int)Math.Ceiling(_repository.CountRelations(category) / (float)rowsPerPage);
            return amountOfPages < 1 ? 1 : amountOfPages;
        }

        public IEnumerable<Relation> OrderByProperty(string property, IEnumerable<Relation> relations) 
        {
            var propertyOfChoice = typeof(Relation).GetProperty(property);

            if (propertyOfChoice == null) 
                propertyOfChoice = typeof(Relation).GetProperty(nameof(Relation.Name));

            var orderedRelations = relations
                .OrderBy(relation => 
                (string)propertyOfChoice.GetValue(relation)).ToList();

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
            string validPostalCode = GetValidPostalCode(relation);
            relation.DefaultPostalCode = validPostalCode;

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

        public string GetValidPostalCode(Relation relation)
        {
            var postalCodeFormat = _repository.GetPostalCodeFormat(relation.DefaultCountry);
            string validCode = ValidateAgainstFormat(postalCodeFormat, relation.DefaultPostalCode);
            Console.WriteLine("\n\n" +
                $"Country : {relation.DefaultCountry}" +
                $"Code : {relation.DefaultPostalCode}" +
                $"Code Pattern : {postalCodeFormat}" +
                $"result : {validCode}");
            return validCode;
        }

        public static string ValidateAgainstFormat(string postalCodeFormat, string postalCode)
        {
            if(string.IsNullOrWhiteSpace(postalCodeFormat))
                return postalCode;

            if (string.IsNullOrWhiteSpace(postalCode))
                return null;

            var result = new StringBuilder();

            for(int formatCursor = 0, codeCursor = 0;
                formatCursor < postalCodeFormat.Length && codeCursor < postalCode.Length;
                formatCursor++, codeCursor++)
            {
                var formatSymbol = postalCodeFormat[formatCursor];
                var currentPostalCharacter = postalCode[codeCursor];
                try
                {
                    if (char.IsPunctuation(formatSymbol) || char.IsWhiteSpace(formatSymbol))
                    {
                        result.Append(formatSymbol);
                        codeCursor--;
                    }
                    else if (formatSymbol == 'N')
                    {
                        if (char.GetUnicodeCategory(currentPostalCharacter) != UnicodeCategory.DecimalDigitNumber)
                            throw new Exception("incompatible format");

                        result.Append(currentPostalCharacter);
                    }
                    else if (formatSymbol == 'L')
                    {
                        if (char.GetUnicodeCategory(currentPostalCharacter) == UnicodeCategory.DecimalDigitNumber)
                            throw new Exception("incompatible format");

                        result.Append(char.ToUpper(currentPostalCharacter));
                    }
                    else if (formatSymbol == 'l')
                    {
                        if (char.GetUnicodeCategory(currentPostalCharacter) == UnicodeCategory.DecimalDigitNumber)
                            throw new Exception("incompatible format");

                        result.Append(char.ToLower(currentPostalCharacter));
                    }
                }
                catch
                {
                    formatCursor--;
                }
            }

            return result.ToString();
        }
    }
}
