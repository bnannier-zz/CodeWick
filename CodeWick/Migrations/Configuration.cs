using System;
using System.Web;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using CodeWick.Models;
using System.Web.Security;
using System.Collections.Generic;
using System.Web.Mvc;

using CodeWick.Areas.Account.Models;
using CodeWick.Helpers;

namespace CodeWick.Migrations {
    internal sealed class Configuration : DbMigrationsConfiguration<CodeWick.Models.CodeWickContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(CodeWick.Models.CodeWickContext context) {
            #region Theme
            if (context.Themes.Where(tbl => tbl.ThemeName == "Phoenix").SingleOrDefault() == null) {
                context.Themes.AddOrUpdate(
                    new Theme { ThemeName = "Phoenix", Abbreviation = "Phoenix" }
                );
                context.SaveChanges();
            }
            #endregion

            #region Settings
            if (context.Settings.Where(tbl => tbl.SiteName == "CodeWick Solutions").SingleOrDefault() == null) {
                context.Settings.AddOrUpdate(
                    new Setting { SiteName = "CodeWick Solutions", ThemeId = context.Themes.First(tbl => tbl.ThemeName == "Phoenix").ThemeId }
                );
                context.SaveChanges();
            }
            #endregion

            #region Category
            if (context.Categories.Where(tbl => tbl.SEOURL == "site").SingleOrDefault() == null) {
                context.Categories.AddOrUpdate(
                    new Category {
                        SEOURL = "site".ToLower(),
                        Title = "Site",
                        Body = "Site",
                        CSS = "",
                        CreatedDate = DateTime.Now,
                        LastUpdate = DateTime.Now
                    }
                );
                context.SaveChanges();
            }
            #endregion

            #region Content
            if (context.Contents.Where(tbl => tbl.SEOURL == "footer").SingleOrDefault() == null) {
                context.Contents.AddOrUpdate(
                    new Content {
                        CategoryId = context.Categories.First(tbl => tbl.SEOURL == "site").CategoryId,
                        SEOURL = "footer".ToLower(),
                        Title = "Footer",
                        Body = "Copyright © 2012 CodeWick Solutions. All Rights Reserved.",
                        CSS = "",
                        CreatedDate = DateTime.Now,
                        LastUpdate = DateTime.Now
                    }
                );
                context.SaveChanges();
            }
            #endregion

            #region User
            //MembershipCreateStatus createStatus = new MembershipCreateStatus();
            //createStatus = ASPNET_Membership.WebSecurity.Register("bobby", "lop12311!", "bobby@codewick.com", true, null, null);

            //if (createStatus == MembershipCreateStatus.Success) {
            //    if (context.Roles.Where(tbl => tbl.RoleName == "administrator").SingleOrDefault() == null) {
            //        context.Roles.AddOrUpdate(
            //            new Role {
            //                RoleName = "administrator",
            //                Description = "Administrator"
            //            }
            //        );
            //        context.SaveChanges();

            //        User user = context.Users.Where(tbl => tbl.Username == "bobby").SingleOrDefault();
            //        user.Roles.Add(context.Roles.First(tbl => tbl.RoleName == "administrator"));
            //        context.Users.AddOrUpdate(user);
            //        context.SaveChanges();
            //    }
            //}
            #endregion
        }
    }
}