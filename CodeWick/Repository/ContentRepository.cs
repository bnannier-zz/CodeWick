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
    public class ContentRepository : IContentRepository
    {
        CodeWickContext context = new CodeWickContext();

        public IQueryable<Content> All
        {
            get { return context.Contents; }
        }

        public IQueryable<Content> AllIncluding(params Expression<Func<Content, object>>[] includeProperties)
        {
            IQueryable<Content> query = context.Contents;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Content Find(long id)
        {
            return context.Contents.Find(id);
        }

        public void InsertOrUpdate(Content content)
        {
            if (content.ContentId == default(long)) {
                // New entity
                context.Contents.Add(content);
            } else {
                // Existing entity
                context.Entry(content).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var content = context.Contents.Find(id);
            context.Contents.Remove(content);
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

    public interface IContentRepository : IDisposable
    {
        IQueryable<Content> All { get; }
        IQueryable<Content> AllIncluding(params Expression<Func<Content, object>>[] includeProperties);
        Content Find(long id);
        void InsertOrUpdate(Content content);
        void Delete(long id);
        void Save();
    }
}