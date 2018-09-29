using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EntityModels.ViewModel.ScheduleExamVM;

namespace EntityModels.ViewModel.BatchVM
{
    public class BatchEditVm
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please provide a code using 5-50 characters!")]
        public string No { get; set; }

        [StringLength(250, MinimumLength = 10,
            ErrorMessage = "Please provide Description of your course with minimum 20 characters!")]
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
        #region ScheduleExam

        public virtual ScheduleExam ScheduleExam { get; set; }

        #endregion

        public ICollection<Course> Courses { get; set; }
        public ICollection<Participant> Participants { get; set; }
        public ICollection<Trainer> Trainers { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<ScheduleExamInfoVm> ScheduleExamInfo { get; set; }
        public IEnumerable<SelectListItem> CourseSelectListItems { get; set; }
        public IEnumerable<SelectListItem> ParticipantSelectListItems { get; set; }
        public IEnumerable<SelectListItem> TrainerSelectListItems { get; set; }
        public IEnumerable<SelectListItem> ExamSelectListItems { get; set; }

    }
}
