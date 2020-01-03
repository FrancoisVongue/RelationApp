﻿using RelationApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RelationApp.Domain.Iterfaces
{
    public interface IRelationService
    {
        public IEnumerable<Category> GetCategories();

        public IEnumerable<Relation> GetAll();

        public Relation GetById(Guid relationId);

        public IEnumerable<Relation> OrderByProperty(string property, IEnumerable<Relation> relations);

        public IEnumerable<Relation> GetByCategory(string category);

        public IEnumerable<Relation> GetFiltered(Expression<Func<Relation, bool>> expression);

        public void Add(Relation relation);

        public void Delete(Guid relationId);

        public void Update(Relation relation);
    }
}
