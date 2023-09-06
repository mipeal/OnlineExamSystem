namespace DBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedOptionAddedAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Options", "Answer", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Options", "Answer");
        }
    }
}
