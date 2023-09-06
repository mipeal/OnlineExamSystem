using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EntityModels.ViewModel.BatchVM
{
    public class BatchEditVm
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please provide a code using 5-50 characters!")]
        public string No { get; set; }
        [StringLength(250, MinimumLength = 10,ErrorMessage = "Please provide Description of your course with minimum 20 characters!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please provide a start date!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please provide an end date!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Please select a course!")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual ScheduleExam ScheduleExam { get; set; }
        public ICollection<Course> Courses { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public virtual ICollection<ScheduleExam> ScheduleExams { get; set; }
        public IEnumerable<SelectListItem> CourseSelectListItems { get; set; }
        public IEnumerable<SelectListItem> ParticipantSelectListItems { get; set; }
        public IEnumerable<SelectListItem> TrainerSelectListItems { get; set; }
        public IEnumerable<SelectListItem> ExamSelectListItems { get; set; }

    }
}
