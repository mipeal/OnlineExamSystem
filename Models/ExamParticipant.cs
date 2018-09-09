using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
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
