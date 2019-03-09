namespace DBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedQuestionRemovedOption : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionBanks", "AnswerOptionId", "dbo.Options");
            DropIndex("dbo.QuestionBanks", new[] { "AnswerOptionId" });
            DropColumn("dbo.QuestionBanks", "AnswerOptionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuestionBanks", "AnswerOptionId", c => c.Int(nullable: false));
            CreateIndex("dbo.QuestionBanks", "AnswerOptionId");
            AddForeignKey("dbo.QuestionBanks", "AnswerOptionId", "dbo.Options", "Id");
        }
    }
}
