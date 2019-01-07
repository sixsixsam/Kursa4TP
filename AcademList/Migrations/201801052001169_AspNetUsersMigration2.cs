namespace AcademList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AspNetUsersMigration2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "StudentGroup");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "StudentGroup", c => c.String());
        }
    }
}
