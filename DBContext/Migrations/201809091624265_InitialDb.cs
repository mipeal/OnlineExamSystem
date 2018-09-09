namespace DBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        No = c.String(nullable: false, maxLength: 10),
                        Description = c.String(nullable: false, maxLength: 150),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false, maxLength: 15),
                        Duration = c.Double(nullable: false),
                        Credit = c.Int(nullable: false),
                        Outline = c.String(nullable: false, maxLength: 250),
                        Fees = c.Double(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false, maxLength: 15),
                        Address = c.String(nullable: false, maxLength: 250),
                        ContactNo = c.String(nullable: false, maxLength: 15),
                        About = c.String(nullable: false, maxLength: 250),
                        Logo = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNo = c.String(nullable: false, maxLength: 15),
                        Name = c.String(nullable: false, maxLength: 50),
                        ContactNo = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 250),
                        City = c.String(nullable: false, maxLength: 20),
                        PostalCode = c.String(nullable: false, maxLength: 15),
                        Country = c.String(nullable: false, maxLength: 30),
                        Profession = c.String(nullable: false, maxLength: 30),
                        HighestAcademic = c.String(nullable: false, maxLength: 30),
                        Image = c.Binary(nullable: false),
                        BatchId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .Index(t => t.BatchId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 15),
                        Name = c.String(nullable: false, maxLength: 50),
                        Type = c.Boolean(nullable: false),
                        ContactNo = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 250),
                        City = c.String(nullable: false, maxLength: 20),
                        PostalCode = c.String(maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 20),
                        Image = c.Binary(nullable: false),
                        CourseId = c.Int(nullable: false),
                        BatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .Index(t => t.CourseId)
                .Index(t => t.BatchId);
            
            CreateTable(
                "dbo.ExamParticipants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamId = c.Int(nullable: false),
                        ParticipantId = c.Int(nullable: false),
                        Marks = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true)
                .ForeignKey("dbo.Participants", t => t.ParticipantId, cascadeDelete: true)
                .Index(t => t.ExamId)
                .Index(t => t.ParticipantId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Serial = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 15),
                        ExamType = c.String(nullable: false, maxLength: 50),
                        Topic = c.String(nullable: false, maxLength: 15),
                        FullMark = c.Double(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        ExamCreated = c.DateTime(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.QuestionBanks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        Question = c.String(nullable: false, maxLength: 50),
                        Type = c.Boolean(nullable: false),
                        Answer = c.String(nullable: false, maxLength: 30),
                        Mark = c.Double(nullable: false),
                        ExamId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Exams", t => t.ExamId)
                .Index(t => t.ExamId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Options = c.String(nullable: false, maxLength: 30),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionBanks", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.ScheduleExams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatchId = c.Int(nullable: false),
                        ExamId = c.Int(nullable: false),
                        Schedule = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .ForeignKey("dbo.Exams", t => t.ExamId)
                .Index(t => t.BatchId)
                .Index(t => t.ExamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleExams", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.ScheduleExams", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Options", "QuestionId", "dbo.QuestionBanks");
            DropForeignKey("dbo.QuestionBanks", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.QuestionBanks", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.ExamParticipants", "ParticipantId", "dbo.Participants");
            DropForeignKey("dbo.ExamParticipants", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Exams", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Trainers", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Trainers", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Participants", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Participants", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Batches", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.ScheduleExams", new[] { "ExamId" });
            DropIndex("dbo.ScheduleExams", new[] { "BatchId" });
            DropIndex("dbo.Options", new[] { "QuestionId" });
            DropIndex("dbo.QuestionBanks", new[] { "CourseId" });
            DropIndex("dbo.QuestionBanks", new[] { "ExamId" });
            DropIndex("dbo.Exams", new[] { "CourseId" });
            DropIndex("dbo.ExamParticipants", new[] { "ParticipantId" });
            DropIndex("dbo.ExamParticipants", new[] { "ExamId" });
            DropIndex("dbo.Trainers", new[] { "BatchId" });
            DropIndex("dbo.Trainers", new[] { "CourseId" });
            DropIndex("dbo.Participants", new[] { "CourseId" });
            DropIndex("dbo.Participants", new[] { "BatchId" });
            DropIndex("dbo.Courses", new[] { "OrganizationId" });
            DropIndex("dbo.Batches", new[] { "CourseId" });
            DropTable("dbo.ScheduleExams");
            DropTable("dbo.Options");
            DropTable("dbo.QuestionBanks");
            DropTable("dbo.Exams");
            DropTable("dbo.ExamParticipants");
            DropTable("dbo.Trainers");
            DropTable("dbo.Participants");
            DropTable("dbo.Organizations");
            DropTable("dbo.Courses");
            DropTable("dbo.Batches");
        }
    }
}
