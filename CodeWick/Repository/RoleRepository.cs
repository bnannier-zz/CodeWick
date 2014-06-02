using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using CodeWick.Models;

namespace CodeWick.Repository {
    public class RoleRepository : IRoleRepository {
        CodeWickContext context = new CodeWickContext();

        public IQueryable<Role> All {
            get { return context.Roles; }
        }

        public IQueryable<Role> AllIncluding(params Expression<Func<Role, object>>[] includeProperties) {
            IQueryable<Role> query = context.Roles;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Role Find(System.Guid id) {
            return context.Roles.Find(id);
        }

        public void InsertOrUpdate(Role role) {
            if (role.RoleId == default(System.Guid)) {
                // New entity
                role.RoleId = Guid.NewGuid();
                context.Roles.Add(role);
            } else {
                // Existing entity
                context.Entry(role).State = EntityState.Modified;
            }
        }

        public void Delete(System.Guid id) {
            var role = context.Roles.Find(id);
            context.Roles.Remove(role);
        }

        public void Save() {
            context.SaveChanges();
        }

        public void Dispose() {
            context.Dispose();
        }
    }

    public interface IRoleRepository : IDisposable {
        IQueryable<Role> All { get; }
        IQueryable<Role> AllIncluding(params Expression<Func<Role, object>>[] includeProperties);
        Role Find(System.Guid id);
        void InsertOrUpdate(Role role);
        void Delete(System.Guid id);
        void Save();
    }
}