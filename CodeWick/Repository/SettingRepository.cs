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
    public class SettingRepository : ISettingRepository
    {
        CodeWickContext context = new CodeWickContext();

        public IQueryable<Setting> All
        {
            get { return context.Settings; }
        }

        public IQueryable<Setting> AllIncluding(params Expression<Func<Setting, object>>[] includeProperties)
        {
            IQueryable<Setting> query = context.Settings;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Setting Find(long id)
        {
            return context.Settings.Find(id);
        }

        public void InsertOrUpdate(Setting setting)
        {
            if (setting.SettingsId == default(long)) {
                // New entity
                context.Settings.Add(setting);
            } else {
                // Existing entity
                context.Entry(setting).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var setting = context.Settings.Find(id);
            context.Settings.Remove(setting);
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

    public interface ISettingRepository : IDisposable
    {
        IQueryable<Setting> All { get; }
        IQueryable<Setting> AllIncluding(params Expression<Func<Setting, object>>[] includeProperties);
        Setting Find(long id);
        void InsertOrUpdate(Setting setting);
        void Delete(long id);
        void Save();
    }
}