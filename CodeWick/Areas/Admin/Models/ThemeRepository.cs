using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using CodeWick.Models;

namespace CodeWick.Areas.Admin.Models {
    public class ThemeRepository : IThemeRepository {
        CodeWickContext context = new CodeWickContext();

        public IQueryable<Theme> All {
            get { return context.Themes; }
        }

        public IQueryable<Theme> AllIncluding(params Expression<Func<Theme, object>>[] includeProperties) {
            IQueryable<Theme> query = context.Themes;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Theme Find(long id) {
            return context.Themes.Find(id);
        }

        public void InsertOrUpdate(Theme theme) {
            if (theme.ThemeId == default(long)) {
                // New entity
                context.Themes.Add(theme);
            } else {
                // Existing entity
                context.Entry(theme).State = EntityState.Modified;
            }
        }

        public void Delete(long id) {
            var theme = context.Themes.Find(id);
            context.Themes.Remove(theme);
        }

        public void Save() {
            context.SaveChanges();
        }

        public void Dispose() {
            context.Dispose();
        }
    }

    public interface IThemeRepository : IDisposable {
        IQueryable<Theme> All { get; }
        IQueryable<Theme> AllIncluding(params Expression<Func<Theme, object>>[] includeProperties);
        Theme Find(long id);
        void InsertOrUpdate(Theme theme);
        void Delete(long id);
        void Save();
    }
}