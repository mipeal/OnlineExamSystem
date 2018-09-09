﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Batch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        [DataType(DataType.Text)]
        public string No { get; set; }
        [Required]
        [StringLength(150)]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        [NotMapped]
        public ICollection<Course> Courses { get; set; }
        [NotMapped]
        public ICollection<Organization> Organizations { get; set; }
        public ICollection<Participant> Participants { get; set; }
        public ICollection<Trainer> Trainers { get; set; }
        [NotMapped]
        public ICollection<Exam> Exams { get; set; }
    }
}
