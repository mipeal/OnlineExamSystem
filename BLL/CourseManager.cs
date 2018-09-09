﻿using System;
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
    }
}
