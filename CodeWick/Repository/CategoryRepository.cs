using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using CodeWick.Models;

namespace CodeWick.Repository
{ 
    public class CategoryRepository : ICategoryRepository
    {
        CodeWickContext context = new CodeWickContext();

        public IQueryable<Category> All
        {
            get { return context.Categories; }
        }

        public IQueryable<Category> AllIncluding(params Expression<Func<Category, object>>[] includeProperties)
        {
            IQueryable<Category> query = context.Categories;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Category Find(long id)
        {
            return context.Categories.Find(id);
        }

        public void InsertOrUpdate(Category category)
        {
            if (category.CategoryId == default(long)) {
                // New entity
                context.Categories.Add(category);
            } else {
                // Existing entity
                context.Entry(category).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface ICategoryRepository : IDisposable
    {
        IQueryable<Category> All { get; }
        IQueryable<Category> AllIncluding(params Expression<Func<Category, object>>[] includeProperties);
        Category Find(long id);
        void InsertOrUpdate(Category category);
        void Delete(long id);
        void Save();
    }
}