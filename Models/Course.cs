using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Duration { get; set; }
        public int Credit { get; set; }
        public string Outline { get; set; }
        public double Fees { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public string OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public ICollection<Trainer> Trainers { get; set; }
        public ICollection<Participant> Participants { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<Batch> Batches { get; set; }
        
        
    }
}
