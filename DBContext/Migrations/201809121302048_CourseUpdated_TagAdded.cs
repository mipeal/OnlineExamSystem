namespace DBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseUpdated_TagAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "CourseId", "dbo.Courses");
            DropIndex("dbo.Tags", new[] { "CourseId" });
            DropTable("dbo.Tags");
        }
    }
}
