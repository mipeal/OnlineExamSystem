using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Exam
    {
        public Exam()
        {
            ExamCreated = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string ExamType { get; set; }
        public string Topic { get; set; }
        public double FullMark { get; set; }
        [DataType(DataType.Duration)]
        public TimeSpan Duration { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExamCreated { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Participant> Participants { get; set; }
    }

}
