using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [StringLength(15)]
        [DataType(DataType.Text)]
        public string Code { get; set; }
        [Required]
        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Required]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }
        [Required]
        [StringLength(250)]
        [DataType(DataType.Text)]
        public string About { get; set; }
        [Required]
        public byte[] Logo { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Trainer> Trainers { get; set; }
        
    }
}
