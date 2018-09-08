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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Batch>().HasIndex(x => x.No).IsUnique();
            modelBuilder.Entity<Course>().HasIndex(x=>x.Code).IsUnique();
            modelBuilder.Entity<Exam>().HasIndex(x => x.Code).IsUnique();
            modelBuilder.Entity<Organization>().HasIndex(x => x.Code).IsUnique();
            modelBuilder.Entity<Participant>().HasIndex(x => x.RegNo).IsUnique();
            modelBuilder.Entity<Trainer>().HasIndex(x => x.Code).IsUnique();
        }
    }
}
