﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace EntityModels.ViewModel.QuestionBankVM
{
    public class QuestionCreateVM
    {
        public int Id { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Question { get; set; }
        [Required]
        [StringLength(10)]
        [DataType(DataType.Text)]
        public string Type { get; set; }
        [Required]
        public double Mark { get; set; }
        [Required]
        public int ExamId { get; set; }
        [ForeignKey("ExamId")]
        public Exam Exam { get; set; }
        [Required]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        public ICollection<Option> Options { get; set; }
        public ICollection<Organization> Organizations { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public List<SelectListItem> OrganizationSelectListItems { get; set; }
        public List<SelectListItem> TypeSelectListItems { get; set; }
    }
}
