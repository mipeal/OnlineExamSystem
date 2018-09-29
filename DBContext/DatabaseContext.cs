using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DBContext
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<QuestionBank> QuestionBanks { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<ScheduleExam> ScheduleExams { get; set; }
        public DbSet<ExamParticipant> ExamParticipants { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Tag> Tags { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>().HasRequired(c=>c.Course).WithMany().HasForeignKey(c=>c.CourseId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Trainer>().HasRequired(c => c.Course).WithMany().HasForeignKey(c => c.CourseId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Exam>().HasRequired(c => c.Course).WithMany().HasForeignKey(c => c.CourseId).WillCascadeOnDelete(false);
            modelBuilder.Entity<QuestionBank>().HasRequired(c => c.Exam).WithMany().HasForeignKey(c => c.ExamId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ScheduleExam>().HasRequired(c => c.Exam).WithMany().HasForeignKey(c => c.ExamId).WillCascadeOnDelete(false);
        }
    }
}
