namespace DBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedOptionAddedOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Options", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Options", "Order");
        }
    }
}
