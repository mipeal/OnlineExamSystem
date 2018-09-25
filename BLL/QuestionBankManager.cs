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

    }
}
