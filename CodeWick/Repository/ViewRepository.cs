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
    public class ViewRepository : IViewRepository
    {
        CodeWickContext context = new CodeWickContext();

        public IQueryable<View> All
        {
            get { return context.Views; }
        }

        public IQueryable<View> AllIncluding(params Expression<Func<View, object>>[] includeProperties)
        {
            IQueryable<View> query = context.Views;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public View Find(long id)
        {
            return context.Views.Find(id);
        }

        public void InsertOrUpdate(View view)
        {
            if (view.ViewId == default(long)) {
                // New entity
                context.Views.Add(view);
            } else {
                // Existing entity
                context.Entry(view).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var view = context.Views.Find(id);
            context.Views.Remove(view);
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

    public interface IViewRepository : IDisposable
    {
        IQueryable<View> All { get; }
        IQueryable<View> AllIncluding(params Expression<Func<View, object>>[] includeProperties);
        View Find(long id);
        void InsertOrUpdate(View view);
        void Delete(long id);
        void Save();
    }
}