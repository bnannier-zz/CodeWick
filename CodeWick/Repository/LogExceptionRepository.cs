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
    public class LogExceptionRepository : ILogExceptionRepository
    {
        CodeWickContext context = new CodeWickContext();

        public IQueryable<LogException> All
        {
            get { return context.LogExceptions; }
        }

        public IQueryable<LogException> AllIncluding(params Expression<Func<LogException, object>>[] includeProperties)
        {
            IQueryable<LogException> query = context.LogExceptions;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public LogException Find(long id)
        {
            return context.LogExceptions.Find(id);
        }

        public void InsertOrUpdate(LogException logexception)
        {
            if (logexception.LogExceptionId == default(long)) {
                // New entity
                context.LogExceptions.Add(logexception);
            } else {
                // Existing entity
                context.Entry(logexception).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var logexception = context.LogExceptions.Find(id);
            context.LogExceptions.Remove(logexception);
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

    public interface ILogExceptionRepository : IDisposable
    {
        IQueryable<LogException> All { get; }
        IQueryable<LogException> AllIncluding(params Expression<Func<LogException, object>>[] includeProperties);
        LogException Find(long id);
        void InsertOrUpdate(LogException logexception);
        void Delete(long id);
        void Save();
    }
}