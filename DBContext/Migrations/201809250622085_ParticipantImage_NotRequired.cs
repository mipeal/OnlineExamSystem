namespace DBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParticipantImage_NotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Participants", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Participants", "Image", c => c.Binary(nullable: false));
        }
    }
}
