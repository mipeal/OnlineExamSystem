using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBContext;
using Models;

namespace Repository
{
    public class CourseRepository
    {
        DatabaseContext db = new DatabaseContext();
        
        public bool Add(Course course)
        {
                db.Courses.Add(course);
                bool isAdded = db.SaveChanges() > 0;
                return isAdded;
        }

        public List<Course> GetAll()
        {
            var courseList = db.Courses.ToList();
            return courseList;
        }
        public Course GetById(int id)
        {
            var course = db.Courses.FirstOrDefault(x => x.Id == id);
            return course;
        }

        public bool Update(Course course)
        {
            db.Courses.Attach(course);
            db.Entry(course).State = EntityState.Modified;
            bool isUpdated = db.SaveChanges() > 0;
            return isUpdated;
        }

        public bool Delete(Course course)
        {
            db.Courses.Remove(course);
            bool isDeleted = db.SaveChanges() > 0;
            return isDeleted;
        }
    }
}
