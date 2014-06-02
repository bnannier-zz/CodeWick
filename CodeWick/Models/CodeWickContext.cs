using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeWick.Models {
    public class CodeWickContext : DbContext {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<CodeWick.Models.CodeWickContext>());

        public DbSet<CodeWick.Models.Setting> Settings { get; set; }

        public DbSet<CodeWick.Models.Theme> Themes { get; set; }

        public DbSet<CodeWick.Models.User> Users { get; set; }

        public DbSet<CodeWick.Models.Role> Roles { get; set; }

        public DbSet<CodeWick.Models.LogMessage> LogMessages { get; set; }

        public DbSet<CodeWick.Models.LogException> LogExceptions { get; set; }

        public DbSet<CodeWick.Models.Category> Categories { get; set; }

        public DbSet<CodeWick.Models.Content> Contents { get; set; }

        public DbSet<CodeWick.Models.RequestQuote> RequestQuotes { get; set; }

        public DbSet<CodeWick.Models.Area> Areas { get; set; }

        public DbSet<CodeWick.Models.View> Views { get; set; }

        public DbSet<CodeWick.Models.Zone> Zones { get; set; }
    }
}