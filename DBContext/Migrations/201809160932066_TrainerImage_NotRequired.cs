namespace DBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrainerImage_NotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainers", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainers", "Image", c => c.Binary(nullable: false));
        }
    }
}
