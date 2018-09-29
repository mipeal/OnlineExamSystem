using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class QuestionBank
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public double Mark { get; set; }
        [Required]
        public int ExamId { get; set; }
        [ForeignKey("ExamId")]
        public Exam Exam { get; set; }
        [Required]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        [InverseProperty("Question")]
        public ICollection<Option> Options { get; set; }
    }
}
