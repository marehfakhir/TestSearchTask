namespace Test_Search_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NewReleaseComingSoon", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NewReleaseWithinPastMonth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NewReleaseWithinPastMonth");
            DropColumn("dbo.Movies", "NewReleaseComingSoon");
        }
    }
}
