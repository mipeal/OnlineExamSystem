namespace DBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUniqueConstraints : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Batches", "No", unique: true);
            CreateIndex("dbo.Courses", "Code", unique: true);
            CreateIndex("dbo.Exams", "Code", unique: true);
            CreateIndex("dbo.Participants", "RegNo", unique: true);
            CreateIndex("dbo.Organizations", "Code", unique: true);
            CreateIndex("dbo.Trainers", "Code", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Trainers", new[] { "Code" });
            DropIndex("dbo.Organizations", new[] { "Code" });
            DropIndex("dbo.Participants", new[] { "RegNo" });
            DropIndex("dbo.Exams", new[] { "Code" });
            DropIndex("dbo.Courses", new[] { "Code" });
            DropIndex("dbo.Batches", new[] { "No" });
        }
    }
}
