using System.ComponentModel.DataAnnotations;

namespace EntityModels
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
