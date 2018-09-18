using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace BLL
{
    public class BatchManager
    {
        BatchRepository _batchRepository=new BatchRepository();
        CourseRepository _courseRepository = new CourseRepository();
        OrganizationRepository _organizationRepository= new OrganizationRepository();
        public bool Add(Batch batch)
        {
            return _batchRepository.Add(batch);
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
