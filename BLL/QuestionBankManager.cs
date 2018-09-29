using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository;

namespace BLL
{
    public class QuestionBankManager
    {
        OrganizationRepository _organizationRepository = new OrganizationRepository();
        CourseRepository _courseRepository = new CourseRepository();
        ExamRepository _examRepository = new ExamRepository();
        QuestionBankRepository _questionRepository =new QuestionBankRepository();
        OptionRepository _optionRepository=new OptionRepository();

        public List<Exam> GetAllExam()
        {
            return _examRepository.GetAll();
        }

        public List<Organization> GetAllOrganization()
        {
            return _organizationRepository.GetAll();
        }

        public List<Course> GetAllCourse()
        {
            return _courseRepository.GetAll();
        }

        public int GetQuestionOrder()
        {
            var order = _questionRepository.GetAll().Count;
            return order;
        }

        public List<QuestionBank> GetAllQuestions(int examId)
        {
            var questions = _questionRepository.GetAll().Where(x=>x.ExamId==examId).ToList();
            return questions;
        }

        public List<Option> GetOptionsofQuestion(int questionId)
        {
            var options = _optionRepository.GetAll().Where(x=>x.QuestionId==questionId).ToList();
            return options;
        }

        public bool Add(QuestionBank question)
        {
            return _questionRepository.Add(question);
        }
    }
}
