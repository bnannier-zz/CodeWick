namespace CodeWick.Migrations {
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration {
        public override void Up() {
            CreateTable(
                "Settings",
                c => new {
                    SettingsId = c.Long(nullable: false, identity: true),
                    SiteName = c.String(nullable: false),
                    ThemeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.SettingsId)
                .ForeignKey("Themes", t => t.ThemeId, cascadeDelete: true)
                .Index(t => t.ThemeId);

            CreateTable(
                "Themes",
                c => new {
                    ThemeId = c.Long(nullable: false, identity: true),
                    ThemeName = c.String(nullable: false),
                    Abbreviation = c.String(nullable: false),
                })
                .PrimaryKey(t => t.ThemeId);

            CreateTable(
                "Users",
                c => new {
                    UserId = c.Guid(nullable: false, identity: true),
                    Username = c.String(nullable: false),
                    Email = c.String(nullable: false),
                    Password = c.String(nullable: false),
                    FirstName = c.String(),
                    LastName = c.String(),
                    Comment = c.String(),
                    IsApproved = c.Boolean(nullable: false),
                    PasswordFailuresSinceLastSuccess = c.Int(nullable: false),
                    LastPasswordFailureDate = c.DateTime(),
                    LastActivityDate = c.DateTime(),
                    LastLockoutDate = c.DateTime(),
                    LastLoginDate = c.DateTime(),
                    ConfirmationToken = c.String(),
                    CreateDate = c.DateTime(),
                    IsLockedOut = c.Boolean(nullable: false),
                    LastPasswordChangedDate = c.DateTime(),
                    PasswordVerificationToken = c.String(),
                    PasswordVerificationTokenExpirationDate = c.DateTime(),
                })
                .PrimaryKey(t => t.UserId);

            CreateTable(
                "Roles",
                c => new {
                    RoleId = c.Guid(nullable: false, identity: true),
                    RoleName = c.String(nullable: false),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.RoleId);

            CreateTable(
                "LogMessages",
                c => new {
                    LogMessageId = c.Long(nullable: false, identity: true),
                    Location = c.String(nullable: false),
                    Message = c.String(nullable: false),
                    Time = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.LogMessageId);

            CreateTable(
                "LogExceptions",
                c => new {
                    LogExceptionId = c.Long(nullable: false, identity: true),
                    Type = c.String(nullable: false),
                    Source = c.String(nullable: false),
                    StackTrace = c.String(nullable: false),
                    ModuleName = c.String(nullable: false),
                    Message = c.String(nullable: false),
                    Exception = c.String(nullable: false),
                    Time = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.LogExceptionId);

            CreateTable(
                "Categories",
                c => new {
                    CategoryId = c.Long(nullable: false, identity: true),
                    ParentId = c.Long(),
                    SEOURL = c.String(nullable: false),
                    Title = c.String(),
                    Body = c.String(nullable: false),
                    CSS = c.String(),
                    CreatedDate = c.DateTime(nullable: false),
                    LastUpdate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("Categories", t => t.ParentId)
                .Index(t => t.ParentId);

            CreateTable(
                "Contents",
                c => new {
                    ContentId = c.Long(nullable: false, identity: true),
                    CategoryId = c.Long(nullable: false),
                    SEOURL = c.String(nullable: false),
                    Title = c.String(),
                    Body = c.String(nullable: false),
                    CSS = c.String(),
                    CreatedDate = c.DateTime(nullable: false),
                    LastUpdate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ContentId)
                .ForeignKey("Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);

            CreateTable(
                "RequestQuotes",
                c => new {
                    RequestQuoteId = c.Long(nullable: false, identity: true),
                    FullName = c.String(nullable: false),
                    Email = c.String(nullable: false),
                    PhoneNumber = c.String(nullable: false),
                })
                .PrimaryKey(t => t.RequestQuoteId);

            CreateTable(
                "Areas",
                c => new {
                    AreaId = c.Long(nullable: false, identity: true),
                    AreaName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.AreaId);

            CreateTable(
                "Views",
                c => new {
                    ViewId = c.Long(nullable: false, identity: true),
                    ViewName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.ViewId);

            CreateTable(
                "Zones",
                c => new {
                    ZoneId = c.Long(nullable: false, identity: true),
                    AreaId = c.Long(nullable: false),
                    ViewId = c.Long(nullable: false),
                    Width = c.Int(nullable: false),
                    Height = c.Int(nullable: false),
                    Order = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ZoneId)
                .ForeignKey("Areas", t => t.AreaId, cascadeDelete: true)
                .ForeignKey("Views", t => t.ViewId, cascadeDelete: true)
                .Index(t => t.AreaId)
                .Index(t => t.ViewId);

            CreateTable(
                "RoleUsers",
                c => new {
                    Role_RoleId = c.Guid(nullable: false),
                    User_UserId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => new { t.Role_RoleId, t.User_UserId })
                .ForeignKey("Roles", t => t.Role_RoleId, cascadeDelete: true)
                .ForeignKey("Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Role_RoleId)
                .Index(t => t.User_UserId);

        }

        public override void Down() {
            DropIndex("RoleUsers", new[] { "User_UserId" });
            DropIndex("RoleUsers", new[] { "Role_RoleId" });
            DropIndex("Zones", new[] { "ViewId" });
            DropIndex("Zones", new[] { "AreaId" });
            DropIndex("Contents", new[] { "CategoryId" });
            DropIndex("Categories", new[] { "ParentId" });
            DropIndex("Settings", new[] { "ThemeId" });
            DropForeignKey("RoleUsers", "User_UserId", "Users");
            DropForeignKey("RoleUsers", "Role_RoleId", "Roles");
            DropForeignKey("Zones", "ViewId", "Views");
            DropForeignKey("Zones", "AreaId", "Areas");
            DropForeignKey("Contents", "CategoryId", "Categories");
            DropForeignKey("Categories", "ParentId", "Categories");
            DropForeignKey("Settings", "ThemeId", "Themes");
            DropTable("RoleUsers");
            DropTable("Zones");
            DropTable("Views");
            DropTable("Areas");
            DropTable("RequestQuotes");
            DropTable("Contents");
            DropTable("Categories");
            DropTable("LogExceptions");
            DropTable("LogMessages");
            DropTable("Roles");
            DropTable("Users");
            DropTable("Themes");
            DropTable("Settings");
        }
    }
}