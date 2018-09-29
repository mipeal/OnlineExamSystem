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
    public class BatchManager
    {
        ExamRepository _examRepository = new ExamRepository();
        BatchRepository _batchRepository=new BatchRepository();
        CourseRepository _courseRepository = new CourseRepository();
        TrainerRepository _trainerRepository = new TrainerRepository() ;
        ParticipantRepository _participantRepository=new ParticipantRepository();
        OrganizationRepository _organizationRepository= new OrganizationRepository();

        public bool Add(Batch batch)
        {
            return _batchRepository.Add(batch);
        }

        public List<Organization> GetAllOrganization()
        {
            return _organizationRepository.GetAll();
        }
        public bool Update(Batch batch)
        {
            return _batchRepository.Update(batch);
        }
        public Organization GetOrganizationById(int id)
        {
            var organization = _organizationRepository.GetById(id);
            return organization;
        }
        public List<Participant> GetAllParticipants()
        {
            return _participantRepository.GetAll();
        }
        public List<Trainer> GetAllTrainers()
        {
            return _trainerRepository.GetAll();
        }

        public List<Course> GetAllCourse()
        {
            return _courseRepository.GetAll();
        }

        public Course GetCourseById(int courseId)
        {
            var course = _courseRepository.GetById(courseId);
            return course;
        }

        public List<Exam> GetAllExams()
        {
            var exams = _examRepository.GetAll();
            return exams;
        }

        public List<Batch> GetAllBatches()
        {
            var batches = _batchRepository.GetAll();
            return batches;
        }
    }
}
