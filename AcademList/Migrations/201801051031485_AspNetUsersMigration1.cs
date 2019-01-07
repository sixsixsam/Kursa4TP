namespace AcademList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AspNetUsersMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "StudentGroup", c => c.String());
            DropColumn("dbo.AspNetUsers", "StudentGroupId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "StudentGroupId", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "StudentGroup");
        }
    }
}
