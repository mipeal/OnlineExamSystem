using System.ComponentModel.DataAnnotations;

namespace EntityModels
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [StringLength(15)]
        [DataType(DataType.Text)]
        public string Code { get; set; }
        [Required]
        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Required]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }
        [Required]
        [StringLength(250)]
        [DataType(DataType.Text)]
        public string About { get; set; }
       // [Required(ErrorMessage = "Please provide your organization logo!")]
        public byte[] Logo { get; set; }
        
    }
}
