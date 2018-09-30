using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBContext;
using EntityModels;

namespace Repository
{
    public class ScheduleExamRepository
    {
        DatabaseContext db = new DatabaseContext();

        public bool Add(ScheduleExam exam)
        {
            db.ScheduleExams.Add(exam);
            bool isAdded = db.SaveChanges() > 0;
            return isAdded;
        }

        public List<ScheduleExam> GetAll()
        {
            var examList = db.ScheduleExams.ToList();
            return examList;
        }
        public ScheduleExam GetById(int id)
        {
            var exam = db.ScheduleExams.FirstOrDefault(x => x.Id == id);
            return exam;
        }

        public bool Update(ScheduleExam exam)
        {
            db.ScheduleExams.Attach(exam);
            db.Entry(exam).State = EntityState.Modified;
            bool isUpdated = db.SaveChanges() > 0;
            return isUpdated;
        }

        public bool Delete(ScheduleExam exam)
        {
            db.ScheduleExams.Remove(exam);
            bool isDeleted = db.SaveChanges() > 0;
            return isDeleted;
        }
    }
}
