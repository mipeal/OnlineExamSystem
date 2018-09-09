using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Please provide a name using 5-50 characters!")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Code length must be atleast 8 characters!")]
        [DataType(DataType.Text)]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please provide the duration of your course!")]
        [DataType(DataType.Duration)]
        public double Duration { get; set; }
        [Required(ErrorMessage = "Please provide the credit of your course!")]
        public int Credit { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 20, ErrorMessage = "Please provide outline of your course with minimum 20 characters!")]
        [DataType(DataType.MultilineText)]
        public string Outline { get; set; }
        [Required(ErrorMessage = "Please provide the fees of your course!")]
        [DataType(DataType.Currency)]
        public double Fees { get; set; }
        [Required]
        public int OrganizationId { get; set; }
        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; }
        [NotMapped]
        public ICollection<Organization> Organizations { get; set; }
        [NotMapped]
        public ICollection<Exam> Exams { get; set; }
        [NotMapped]
        public ICollection<Participant> Participants { get; set; }
        [NotMapped]
        public ICollection<Trainer> Trainers { get; set; }
        [NotMapped]
        public List<SelectListItem> OrganizationSelectListItems { get; set; }
    }
}
