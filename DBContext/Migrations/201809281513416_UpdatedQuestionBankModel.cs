namespace DBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedQuestionBankModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuestionBanks", "AnswerOptionId", c => c.Int(nullable: false));
            AlterColumn("dbo.QuestionBanks", "Question", c => c.String(nullable: false));
            AlterColumn("dbo.QuestionBanks", "Type", c => c.String(nullable: false));
            CreateIndex("dbo.QuestionBanks", "AnswerOptionId");
            AddForeignKey("dbo.QuestionBanks", "AnswerOptionId", "dbo.Options", "Id");
            DropColumn("dbo.QuestionBanks", "Answer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuestionBanks", "Answer", c => c.String(nullable: false, maxLength: 30));
            DropForeignKey("dbo.QuestionBanks", "AnswerOptionId", "dbo.Options");
            DropIndex("dbo.QuestionBanks", new[] { "AnswerOptionId" });
            AlterColumn("dbo.QuestionBanks", "Type", c => c.Boolean(nullable: false));
            AlterColumn("dbo.QuestionBanks", "Question", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.QuestionBanks", "AnswerOptionId");
        }
    }
}
