using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string About { get; set; }
        public byte[] Logo { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Trainer> Trainers { get; set; }
        
    }
}
