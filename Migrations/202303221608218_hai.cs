namespace HH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hai : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Contributors", "ProjectId");
            AddForeignKey("dbo.Contributors", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contributors", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Contributors", new[] { "ProjectId" });
        }
    }
}
