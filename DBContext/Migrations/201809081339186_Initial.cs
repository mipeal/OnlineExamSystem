namespace DBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 15),
                        ExamType = c.String(nullable: false, maxLength: 50),
                        Topic = c.String(nullable: false, maxLength: 15),
                        FullMark = c.Double(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        ExamCreated = c.DateTime(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Batch_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Batches", t => t.Batch_Id)
                .Index(t => t.CourseId)
                .Index(t => t.Batch_Id);
            
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
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.BatchId)
                .Index(t => t.Course_Id);
            
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
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: false)
                .Index(t => t.ExamId)
                .Index(t => t.CourseId);
            
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
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .Index(t => t.CourseId)
                .Index(t => t.BatchId);
            
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
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: false)
                .Index(t => t.BatchId)
                .Index(t => t.ExamId);
            
            CreateTable(
                "dbo.ParticipantExams",
                c => new
                    {
                        Participant_Id = c.Int(nullable: false),
                        Exam_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Participant_Id, t.Exam_Id })
                .ForeignKey("dbo.Participants", t => t.Participant_Id, cascadeDelete: true)
                .ForeignKey("dbo.Exams", t => t.Exam_Id, cascadeDelete: false)
                .Index(t => t.Participant_Id)
                .Index(t => t.Exam_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleExams", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.ScheduleExams", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Exams", "Batch_Id", "dbo.Batches");
            DropForeignKey("dbo.Trainers", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Trainers", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Participants", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.QuestionBanks", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.QuestionBanks", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.ParticipantExams", "Exam_Id", "dbo.Exams");
            DropForeignKey("dbo.ParticipantExams", "Participant_Id", "dbo.Participants");
            DropForeignKey("dbo.Participants", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Exams", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Batches", "CourseId", "dbo.Courses");
            DropIndex("dbo.ParticipantExams", new[] { "Exam_Id" });
            DropIndex("dbo.ParticipantExams", new[] { "Participant_Id" });
            DropIndex("dbo.ScheduleExams", new[] { "ExamId" });
            DropIndex("dbo.ScheduleExams", new[] { "BatchId" });
            DropIndex("dbo.Trainers", new[] { "BatchId" });
            DropIndex("dbo.Trainers", new[] { "CourseId" });
            DropIndex("dbo.QuestionBanks", new[] { "CourseId" });
            DropIndex("dbo.QuestionBanks", new[] { "ExamId" });
            DropIndex("dbo.Participants", new[] { "Course_Id" });
            DropIndex("dbo.Participants", new[] { "BatchId" });
            DropIndex("dbo.Exams", new[] { "Batch_Id" });
            DropIndex("dbo.Exams", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "OrganizationId" });
            DropIndex("dbo.Batches", new[] { "CourseId" });
            DropTable("dbo.ParticipantExams");
            DropTable("dbo.ScheduleExams");
            DropTable("dbo.Trainers");
            DropTable("dbo.Organizations");
            DropTable("dbo.QuestionBanks");
            DropTable("dbo.Participants");
            DropTable("dbo.Exams");
            DropTable("dbo.Courses");
            DropTable("dbo.Batches");
        }
    }
}
