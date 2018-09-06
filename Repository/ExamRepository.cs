using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBContext;
using Models;

namespace Repository
{
    class ExamRepository
    {
        DatabaseContext db = new DatabaseContext();

        public bool Add(Exam exam)
        {
            db.Exams.Add(exam);
            bool isAdded = db.SaveChanges() > 0;
            return isAdded;
        }

        public List<Exam> GetAll()
        {
            var examList = db.Exams.ToList();
            return examList;
        }
        public Exam GetById(int id)
        {
            var exam = db.Exams.FirstOrDefault(x => x.Id == id);
            return exam;
        }

        public bool Update(Exam exam)
        {
            db.Exams.Attach(exam);
            db.Entry(exam).State = EntityState.Modified;
            bool isUpdated = db.SaveChanges() > 0;
            return isUpdated;
        }

        public bool Delete(Exam exam)
        {
            db.Exams.Remove(exam);
            bool isDeleted = db.SaveChanges() > 0;
            return isDeleted;
        }
    }
}
