using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.ViewModel.TrainerVM
{
    public class TrainerCreateVm
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15, MinimumLength =3, ErrorMessage ="Please provide a trainer code between 3 to 15 characters!")]
        public string Code { get; set; }
        [Required]
        [StringLength(50)]
         public string Name { get; set; }
        [Required]
        public bool Type { get; set; }
        [Required]
        [StringLength(15)]
        public string ContactNo { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(250)]
        public string Address { get; set; }
        [Required]
        [StringLength(20)]
        public string City { get; set; }
        [StringLength(10)]
        public string PostalCode { get; set; }
        [Required]
        [StringLength(20)]
        public string Country { get; set; }
        [Required]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        [Required]
        public int BatchId { get; set; }
        [ForeignKey("BatchId")]
        public virtual Batch Batch { get; set; }
        public ICollection<Organization> Organizations { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Batch> Batches { get; set; }
        public List<SelectListItem> OrganizationSelectListItems { get; set; }
        public List<SelectListItem> CourseSelectListItems { get; set; }
        public List<SelectListItem> BatchSelectListItems { get; set; }

    }
}
