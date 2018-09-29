using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels
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
        public int OrganizationId { get; set; }
        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; }
        [NotMapped]
        public virtual ICollection<Trainer> Trainers { get; set; }
        [NotMapped]
        public virtual ICollection<Exam> Exams { get; set; }
        
    }
}
