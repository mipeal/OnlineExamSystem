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
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Please provide a course name using 5-50 characters!")]
        public string Course { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Please provide a batch number!")]
        public double BatchNo { get; set; }
        [StringLength(250, MinimumLength = 10, ErrorMessage = "Please provide Description of your course with minimum 20 characters!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please provide a start date!")]
        public string StartDate { get; set; }
        [Required(ErrorMessage = "Please provide an end date!")]
        public string EndDate { get; set; }
        public ICollection<Tag> Tags { get; set; }
        [Required(ErrorMessage = "Please select a organization!")]
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public ICollection<Organization> Organizations { get; set; }
        public IEnumerable<SelectListItem> TagsSelectListItems { get; set; }
        public IEnumerable<SelectListItem> OrganizationSelectListItems { get; set; }

    }
}
