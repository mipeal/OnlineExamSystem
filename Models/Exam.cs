using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Serial { get; set; }
        [Required]
        [StringLength(15)]
        [DataType(DataType.Text)]
        public string Code { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string ExamType { get; set; }
        [Required]
        [StringLength(15)]
        [DataType(DataType.Text)]
        public string Topic { get; set; }
        [Required]
        public double FullMark { get; set; }
        [Required]
        [DataType(DataType.Duration)]
        public TimeSpan Duration { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExamCreated { get; set; }
        [Required]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        
    }

}
