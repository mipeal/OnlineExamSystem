using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TrainerManager
    {
        OrganizationRepository _organizationRepository = new OrganizationRepository();
        CourseRepository _courseRepository = new CourseRepository();
        BatchRepository _batchRepository = new BatchRepository();
        TrainerRepository _trainerRepository = new TrainerRepository();
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

        public bool Add(Trainer trainer)
        {
            return _trainerRepository.Add(trainer);
        }
    }
}
