using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using CodeWick.Models;

namespace CodeWick.Areas.Admin.Models
{ 
    public class AreaRepository : IAreaRepository
    {
        CodeWickContext context = new CodeWickContext();

        public IQueryable<Area> All
        {
            get { return context.Areas; }
        }

        public IQueryable<Area> AllIncluding(params Expression<Func<Area, object>>[] includeProperties)
        {
            IQueryable<Area> query = context.Areas;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Area Find(long id)
        {
            return context.Areas.Find(id);
        }

        public void InsertOrUpdate(Area area)
        {
            if (area.AreaId == default(long)) {
                // New entity
                context.Areas.Add(area);
            } else {
                // Existing entity
                context.Entry(area).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var area = context.Areas.Find(id);
            context.Areas.Remove(area);
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

    public interface IAreaRepository : IDisposable
    {
        IQueryable<Area> All { get; }
        IQueryable<Area> AllIncluding(params Expression<Func<Area, object>>[] includeProperties);
        Area Find(long id);
        void InsertOrUpdate(Area area);
        void Delete(long id);
        void Save();
    }
}