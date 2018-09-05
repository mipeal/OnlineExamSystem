using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [StringLength(15)]
        [DataType(DataType.Text)]
        public string Code { get; set; }
        
    }
}
