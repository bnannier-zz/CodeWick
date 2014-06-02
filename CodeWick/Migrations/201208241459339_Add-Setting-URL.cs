namespace CodeWick.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddSettingURL : DbMigration
    {
        public override void Up()
        {
            AddColumn("Settings", "URL", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Settings", "URL");
        }
    }
}
