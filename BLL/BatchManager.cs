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
        ScheduleExamRepository _scheduleExamRepository = new ScheduleExamRepository();

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

        public Participant GetParticipantById(int id)
        {
            var participants = _participantRepository.GetById(id);
            return participants;
        }

        public Trainer GetInfoByTrainerId(int id)
        {
            var trainer = _trainerRepository.GetById(id);
            return trainer;
        }

        public Exam GetExamById(int id)
        {
            var exam = _examRepository.GetById(id);
            return exam;
        }

        public bool AddExamSchedule(ICollection<ScheduleExam> entityScheduleExams)
        {
            var counter = 0;
            foreach (var exam in entityScheduleExams)
            {
                if (_scheduleExamRepository.Add(exam) == true)
                {
                    counter++;
                }
            }
            if (counter == entityScheduleExams.Count)
            {
                return true;
            }
            return false;
        }

        public bool AssignTrainers(ICollection<Trainer> trainers)
        {
            var counter = 0;
            foreach (var trainer in trainers)
            {
                if (_trainerRepository.Update(trainer) == true)
                {
                    counter++;
                }
            }
            if (counter == trainers.Count)
            {
                return true;
            }
            return false;
        }

        public bool AssignParticipants(ICollection<Participant> participants)
        {
            var counter = 0;
            foreach (var participant in participants)
            {
                if (_participantRepository.Update(participant) == true)
                {
                    counter++;
                }
            }
            if (counter == participants.Count)
            {
                return true;
            }
            return false;
        }

        public ICollection<Trainer> GetTrainersByBatchId(int entityId)
        {
            var trainers = _trainerRepository.GetAll().Where(x => x.BatchId == entityId).ToList();
            return trainers;
        }

        public ICollection<Participant> GetParticipantByBatchId(int id)
        {
            var participants = _participantRepository.GetAll().Where(x => x.BatchId == id).ToList();
            return participants;
        }

    }
}
