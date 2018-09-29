using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EntityModels.ViewModel.CourseVM
{
    public class CourseCreateVm
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Please provide a name using 5-50 characters!")]
        public string Name { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Code length must be at least 8 characters!")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please provide the duration of your course!")]
        public double Duration { get; set; }
        [Required(ErrorMessage = "Please provide the credit of your course!")]
        public int Credit { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "Please provide outline of your course with minimum 20 characters!")]
        public string Outline { get; set; }
        [Required(ErrorMessage = "Please provide the fees of your course!")]
        public double Fees { get; set; }
        public ICollection<Tag> Tags { get; set; }
        [Required(ErrorMessage = "Please select a organization!")]
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public ICollection<Organization> Organizations { get; set; }
        public IEnumerable<SelectListItem> TagsSelectListItems { get; set; }
        public IEnumerable<SelectListItem> OrganizationSelectListItems { get; set; }
    }
}