using System;
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
        public bool Add(Course course)
        {
            return _courseRepository.Add(course);
        }
    }
}
