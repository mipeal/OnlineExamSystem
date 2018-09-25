using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ParticipantManager
    {
        OrganizationRepository _organizationRepository = new OrganizationRepository();
        CourseRepository _courseRepository = new CourseRepository();
        BatchRepository _batchRepository = new BatchRepository();
        ParticipantRepository _participantRepository = new ParticipantRepository();


        public List<Batch> GetAllBatch()
        {
            return _batchRepository.GetAll();
        }

        public List<Organization> GetAllOrganization()
        {
            return _organizationRepository.GetAll();
        }

        public List<Course> GetAllCourse()
        {
            return _courseRepository.GetAll();
        }
        public List<Participant> GetAllParticipants()
        {
            return _participantRepository.GetAll();
        }

        public bool Add(Participant participant)
        {
           return _participantRepository.Add(participant);
        }
    }
}
