using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Question
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Options { get; set; }
        public string Answer { get; set; }
        public double Mark { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
