using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModel.ExamVM
{
    public class ExamCreateVm
    {
        public ExamCreateVm()
        {
            ExamCreated = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public int Serial { get; set; }
        [Required]
        [StringLength(15)]
        public string Code { get; set; }
        [Required]
        [StringLength(50)]
        public string ExamType { get; set; }
        [Required]
        [StringLength(15)]
        public string Topic { get; set; }
        [Required]
        public double FullMark { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        public DateTime ExamCreated { get; set; }
        [Required]
        public int CourseId { get; set; }
        //public virtual Course Course { get; set; }
        public ICollection<Organization> Organizations { get; set; }
       // public ICollection<Course> Courses { get; set; }
        public ICollection<Participant> Participants { get; set; }
        public ICollection<QuestionBank> Questions { get; set; }
    }
}