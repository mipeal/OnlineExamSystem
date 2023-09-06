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
    public class CourseManager
    {
        CourseRepository _courseRepository=new CourseRepository();
        OrganizationRepository _organizationRepository=new OrganizationRepository();
        TrainerRepository _trainerRepository = new TrainerRepository();
        TagRepository _tagRepository = new TagRepository();
        ExamRepository _examRepository =new ExamRepository();
        ParticipantRepository _participantRepository =new ParticipantRepository();
        BatchRepository _batchRepository=new BatchRepository();
        public bool Add(Course course)
        {
            return _courseRepository.Add(course);
        }

        public List<Organization> GetAllOrganization()
        {
            var organizations = _organizationRepository.GetAll();
            return organizations;
        }

        public bool Update(Course course)
        {
            return _courseRepository.Update(course);
        }

        public Organization GetOrganizationById(int id)
        {
            var organization = _organizationRepository.GetById(id);
            return organization;
        }

        public List<Tag> GetAllTags()
        {
            var tags= _tagRepository.GetAll();
            return tags;
        }

        public List<Trainer> GetAllTrainers()
        {
            var trainers=_trainerRepository.GetAll();
            return trainers;
        }

        public int ExamCounter()
        {
            var noOfCount = _examRepository.GetAll().Count;
            return noOfCount;
        }

        public Trainer GetInfoByTrainerId(int id)
        {
            var trainer = _trainerRepository.GetById(id);
            return trainer;
        }

        public bool AddExam(List<Exam> entityExams)
        {
            var counter = 0;
            foreach (var exam in entityExams)
            {
                if (_examRepository.Add(exam) == true)
                {
                    counter++;
                }
            }
            if (counter == entityExams.Count)
            {
                return true;
            }
            return false;
        }

        public bool AssignTrainers(List<Trainer> entityTrainers)
        {
            var counter = 0;
            foreach (var trainer in entityTrainers)
            {
                if (_trainerRepository.Update(trainer) == true)
                {
                    counter++;
                }
            }
            if (counter == entityTrainers.Count)
            {
                return true;
            }
            return false;
        }

        public List<Course> GetAllCourseInfoForSearch(int id)
        {
            var courses = _courseRepository.GetAll().Where(x => x.OrganizationId == id).ToList();
            return courses;
        }

        public int GetAllParticipantsForSearch(int courseId)
        {
            var participants = _participantRepository.GetAll().Where(x => x.CourseId == courseId).ToList();
            return participants.Count;
        }

        public int GetAllBatchForSearch(int courseId)
        {
            var batches = _batchRepository.GetAll().Where(x => x.CourseId == courseId).ToList();
            return batches.Count;
        }

        public string GetAllTrainersForSearch(int courseId)
        {
            var trainers = _trainerRepository.GetAll().Where(x=>x.CourseId == courseId).ToList();
            var trainerNames = string.Join("|", trainers.Select(x => x.Name));
            return trainerNames;
        }

        public List<Course> GetAllCourse()
        {
            var courses = _courseRepository.GetAll().ToList();
            return courses;
        }

        public List<Trainer> GetTrainersByCourseId(int courseId)
        {
            var trainers = _trainerRepository.GetAll().Where(x => x.CourseId == courseId).ToList();
            return trainers;
        }

        public List<Exam> GetExamsByCourseId(int courseId)
        {
            var exams = _examRepository.GetAll().Where(x => x.CourseId == courseId).ToList();
            return exams;
        }
    }
}
