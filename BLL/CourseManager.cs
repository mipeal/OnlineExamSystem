using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
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
    }
}
