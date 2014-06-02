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
    public class LogMessageRepository : ILogMessageRepository
    {
        CodeWickContext context = new CodeWickContext();

        public IQueryable<LogMessage> All
        {
            get { return context.LogMessages; }
        }

        public IQueryable<LogMessage> AllIncluding(params Expression<Func<LogMessage, object>>[] includeProperties)
        {
            IQueryable<LogMessage> query = context.LogMessages;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public LogMessage Find(long id)
        {
            return context.LogMessages.Find(id);
        }

        public void InsertOrUpdate(LogMessage logmessage)
        {
            if (logmessage.LogMessageId == default(long)) {
                // New entity
                context.LogMessages.Add(logmessage);
            } else {
                // Existing entity
                context.Entry(logmessage).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var logmessage = context.LogMessages.Find(id);
            context.LogMessages.Remove(logmessage);
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

    public interface ILogMessageRepository : IDisposable
    {
        IQueryable<LogMessage> All { get; }
        IQueryable<LogMessage> AllIncluding(params Expression<Func<LogMessage, object>>[] includeProperties);
        LogMessage Find(long id);
        void InsertOrUpdate(LogMessage logmessage);
        void Delete(long id);
        void Save();
    }
}