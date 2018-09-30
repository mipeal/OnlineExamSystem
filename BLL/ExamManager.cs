using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModels;
using Repository;

namespace BLL
{
    public class ExamManager
    {
        OrganizationRepository _organizationRepository=new OrganizationRepository();
        CourseRepository _courseRepository=new CourseRepository();
        ExamRepository _examRepository = new ExamRepository();
        ParticipantRepository _participantRepository=new ParticipantRepository();
        public List<Organization> GetAllOrganization()
        {
            var organization = _organizationRepository.GetAll();
            return organization;
        }

        public List<Exam> GetExamInfoByCourseId(int id)
        {
            var exams = _examRepository.GetAll();
            var examsByCourseId = exams.Where(x => x.CourseId == id).ToList();
            return examsByCourseId;
        }

        public bool Add(Exam exam)
        {
            return _examRepository.Add(exam);
        }

        public int ExamCounter()
        {
            return _examRepository.GetAll().Count;
        }

        public List<Exam> GetAllExams()
        {
            var exams = _examRepository.GetAll();
            return exams;
        }

        public List<Course> GetInfoByOrganizationId(int id)
        {
            var courses = _courseRepository.GetAll();
            var courseByOrganizationId = courses.Where(x => x.OrganizationId == id).ToList();
            return courseByOrganizationId;
        }

        public List<Participant> GetParticipantInfoByCourseId(int id)
        {
            var participant = _participantRepository.GetAll();
            var participantsByCourseId = participant.Where(x => x.CourseId == id).ToList();
            return participantsByCourseId;
        }
    }
}
