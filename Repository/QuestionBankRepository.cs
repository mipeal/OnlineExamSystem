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
    class QuestionBankRepository
    {
        DatabaseContext db = new DatabaseContext();

        public bool Add(QuestionBank question)
        {
            db.QuestionBanks.Add(question);
            bool isAdded = db.SaveChanges() > 0;
            return isAdded;
        }

        public List<QuestionBank> GetAll()
        {
            var questionList = db.QuestionBanks.ToList();
            return questionList;
        }
        public QuestionBank GetById(int id)
        {
            var question = db.QuestionBanks.FirstOrDefault(x => x.Id == id);
            return question;
        }

        public List<QuestionBank> GetByExamId(int examId)
        {
            var questionList = db.QuestionBanks.Where(c => c.ExamId == examId).ToList();
            return questionList;
        }

        public bool Update(QuestionBank question)
        {
            db.QuestionBanks.Attach(question);
            db.Entry(question).State = EntityState.Modified;
            bool isUpdated = db.SaveChanges() > 0;
            return isUpdated;
        }

        public bool Delete(QuestionBank question)
        {
            db.QuestionBanks.Remove(question);
            bool isDeleted = db.SaveChanges() > 0;
            return isDeleted;
        }
    }
}
