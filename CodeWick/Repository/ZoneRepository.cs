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
    public class ZoneRepository : IZoneRepository
    {
        CodeWickContext context = new CodeWickContext();

        public IQueryable<Zone> All
        {
            get { return context.Zones; }
        }

        public IQueryable<Zone> AllIncluding(params Expression<Func<Zone, object>>[] includeProperties)
        {
            IQueryable<Zone> query = context.Zones;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Zone Find(long id)
        {
            return context.Zones.Find(id);
        }

        public void InsertOrUpdate(Zone zone)
        {
            if (zone.ZoneId == default(long)) {
                // New entity
                context.Zones.Add(zone);
            } else {
                // Existing entity
                context.Entry(zone).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var zone = context.Zones.Find(id);
            context.Zones.Remove(zone);
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

    public interface IZoneRepository : IDisposable
    {
        IQueryable<Zone> All { get; }
        IQueryable<Zone> AllIncluding(params Expression<Func<Zone, object>>[] includeProperties);
        Zone Find(long id);
        void InsertOrUpdate(Zone zone);
        void Delete(long id);
        void Save();
    }
}