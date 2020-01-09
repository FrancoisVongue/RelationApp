using RelationApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RelationApp.Domain.Iterfaces
{
    public interface IRelationService
    {
        IEnumerable<string> GetCategories();

        IEnumerable<Relation> GetAll();

        IEnumerable<Relation> GetRelations(ref int page, int rowsPerPage, string sortfield, string category); 

        int CountPages(int rowsPerPage, string category);

        Relation GetById(Guid relationId);

        IEnumerable<Relation> OrderByProperty(string property, IEnumerable<Relation> relations);

        IEnumerable<Relation> GetByCategory(string category);

        IEnumerable<Relation> GetFiltered(Expression<Func<Relation, bool>> expression);

        void Add(Relation relation);

        void Delete(Guid relationId);

        void Update(Relation relation);
    }
}
