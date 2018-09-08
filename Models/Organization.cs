using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50,MinimumLength = 5,ErrorMessage = "Please provide a name using 5-50 characters!")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [StringLength(15,MinimumLength = 3,ErrorMessage = "Code length must be atleast 8 characters!")]
        [DataType(DataType.Text)]
        public string Code { get; set; }
        [Required]
        [StringLength(250,ErrorMessage = "Please provide a valid address!")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Required]
        [StringLength(15,MinimumLength = 11,ErrorMessage = "Please provide a valid contact number(Minimun 11 digit)!")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 20, ErrorMessage = "Please provide organization about with minimum 20 characters!")]
        [DataType(DataType.Text)]
        public string About { get; set; }
       // [Required(ErrorMessage = "Please provide your organization logo!")]
        public byte[] Logo { get; set; }

        public ICollection<Course> Courses { get; set; }
        
    }
}
