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
    public class RequestQuoteRepository : IRequestQuoteRepository
    {
        CodeWickContext context = new CodeWickContext();

        public IQueryable<RequestQuote> All
        {
            get { return context.RequestQuotes; }
        }

        public IQueryable<RequestQuote> AllIncluding(params Expression<Func<RequestQuote, object>>[] includeProperties)
        {
            IQueryable<RequestQuote> query = context.RequestQuotes;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public RequestQuote Find(long id)
        {
            return context.RequestQuotes.Find(id);
        }

        public void InsertOrUpdate(RequestQuote requestquote)
        {
            if (requestquote.RequestQuoteId == default(long)) {
                // New entity
                context.RequestQuotes.Add(requestquote);
            } else {
                // Existing entity
                context.Entry(requestquote).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var requestquote = context.RequestQuotes.Find(id);
            context.RequestQuotes.Remove(requestquote);
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

    public interface IRequestQuoteRepository : IDisposable
    {
        IQueryable<RequestQuote> All { get; }
        IQueryable<RequestQuote> AllIncluding(params Expression<Func<RequestQuote, object>>[] includeProperties);
        RequestQuote Find(long id);
        void InsertOrUpdate(RequestQuote requestquote);
        void Delete(long id);
        void Save();
    }
}