using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels
{
    public class ScheduleExam
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BatchId { get; set; }
        [ForeignKey("BatchId")]
        public Batch Batch { get; set; }
        [Required]
        public int ExamId { get; set; }
        [ForeignKey("ExamId")]
        public Exam Exam { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Schedule { get; set; }
    }
}
