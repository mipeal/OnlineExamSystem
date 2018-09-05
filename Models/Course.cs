using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Course
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
        [DataType(DataType.Duration)]
        public double Duration { get; set; }
        [Required]
        public int Credit { get; set; }
        [Required]
        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        public string Outline { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Fees { get; set; }
        [Required]
        public string OrganizationId { get; set; }
        [Required]
        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Trainer> Trainers { get; set; }
        public ICollection<Participant> Participants { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<Batch> Batches { get; set; }
        
        
    }
}
