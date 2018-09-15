using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace OnlineExamSystem.Models.CourseVM
{
    public class CourseAssignTrainerVm
    {
        public ICollection<Trainer> Trainers { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}