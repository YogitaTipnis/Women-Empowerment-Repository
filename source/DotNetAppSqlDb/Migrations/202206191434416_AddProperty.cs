namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "Title", c => c.String());
            AddColumn("dbo.Todoes", "Story", c => c.String());
            DropColumn("dbo.Todoes", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Todoes", "Description", c => c.String());
            DropColumn("dbo.Todoes", "Story");
            DropColumn("dbo.Todoes", "Title");
        }
    }
}
