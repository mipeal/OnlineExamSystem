using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.ViewModel.BatchVM
{
    public class BatchCreateVm
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
        public ICollection<Organization> Organizations { get; set; }
        public ICollection<Participant> Participants { get; set; }
        public ICollection<Trainer> Trainers { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public IEnumerable<SelectListItem> CourseSelectListItems { get; set; }

    }
}
