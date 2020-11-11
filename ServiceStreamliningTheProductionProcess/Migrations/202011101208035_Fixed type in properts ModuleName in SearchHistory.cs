namespace ServiceStreamliningTheProductionProcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedtypeinpropertsModuleNameinSearchHistory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SearchHistories", "ModuleName1", c => c.String());
            AlterColumn("dbo.SearchHistories", "ModuleName2", c => c.String());
            AlterColumn("dbo.SearchHistories", "ModuleName3", c => c.String());
            AlterColumn("dbo.SearchHistories", "ModuleName4", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SearchHistories", "ModuleName4", c => c.Int(nullable: false));
            AlterColumn("dbo.SearchHistories", "ModuleName3", c => c.Int(nullable: false));
            AlterColumn("dbo.SearchHistories", "ModuleName2", c => c.Int(nullable: false));
            AlterColumn("dbo.SearchHistories", "ModuleName1", c => c.Int(nullable: false));
        }
    }
}
