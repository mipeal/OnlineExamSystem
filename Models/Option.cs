using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Option
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        [DataType(DataType.Text)]
        public string Options { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public QuestionBank Question { get; set; }
    }
}
