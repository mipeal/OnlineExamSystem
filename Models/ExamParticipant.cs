using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels
{
    public class ExamParticipant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ExamId { get; set; }
        [ForeignKey("ExamId")]
        public Exam Exam { get; set; }
        [Required]
        public int ParticipantId { get; set; }
        [ForeignKey("ParticipantId")]
        public Participant Participant { get; set; }
        public double Marks { get; set; }
    }
}
