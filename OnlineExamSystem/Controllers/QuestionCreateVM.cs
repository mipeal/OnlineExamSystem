using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Models;

namespace OnlineExamSystem.Controllers
{
    public class QuestionCreateVM
    {
        public QuestionCreateVM()
        {
        }

        public List<SelectListItem> OrganizationSelectListItems { get; set; }
        public List<SelectListItem> CourseSelectListItems { get; set; }
        public List<SelectListItem> ExamSelectListItems { get; set; }
        [Required]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        public string Exam { get; set; }
        public int ExamId { get; set; }
       
    }
}