using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels
{
    public class Trainer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        [DataType(DataType.Text)]
        public string Code { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        public bool Type { get; set; }
        [Required]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Required]
        [StringLength(20)]
        [DataType(DataType.Text)]
        public string City { get; set; }
        [StringLength(10)]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }
        [Required]
        [StringLength(20)]
        [DataType(DataType.Text)]
        public string Country { get; set; }
        //[Required]
        public byte[] Image { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        public int BatchId { get; set; }
        [ForeignKey("BatchId")]
        public Batch Batch { get; set; }
    }
}
