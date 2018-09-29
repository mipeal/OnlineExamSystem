using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EntityModels.ViewModel.BatchVM
{
    public class BatchInformationVm
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please provide a code using 5-50 characters!")]
        public string No { get; set; }
        [StringLength(250, MinimumLength = 10, ErrorMessage = "Please provide Description of your course with minimum 20 characters!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please provide a start date!")]
        public string StartDate { get; set; }
        [Required(ErrorMessage = "Please provide an end date!")]
        public string EndDate { get; set; }
        [Required(ErrorMessage = "Please select a course!")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<SelectListItem> CourseSelectListItems { get; set; }
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public ICollection<Organization> Organizations { get; set; }
        public List<SelectListItem> OrganizationSelectListItems { get; set; }
        public ICollection<Participant> Participants { get; set; }
        public ICollection<Trainer> Trainers { get; set; }
        public ICollection<Exam> Exams { get; set; }

    }
}
