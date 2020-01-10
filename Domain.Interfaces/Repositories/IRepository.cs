using System.Collections.Generic;
using System;
using RelationApp.Domain.Models;

namespace RelationApp.Domain.Iterfaces
{
    public interface IRepository
    {
        IEnumerable<Category> GetCategories();

        IEnumerable<Relation> GetAll();

        int CountRelations(string category);

        IEnumerable<Relation> GetFiltered(Func<Relation, bool> predicate);

        IEnumerable<Relation> GetByCategory(string categoryName);

        string GetPostalCodeFormat(string country);

        Relation GetById(Guid id);

        void Add(Relation t);

        void Delete(Relation t);

        void Update(Relation t);

        bool Exists(Guid id);
    }
}
