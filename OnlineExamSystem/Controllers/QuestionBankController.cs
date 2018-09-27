using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models.ViewModel.QuestionBankVM;
using Models.ViewModel.TrainerVM;

namespace OnlineExamSystem.Controllers
{
    public class QuestionBankController : Controller
    {
        QuestionBankManager _questionBankManager=new QuestionBankManager();
        [HttpGet]
        public ActionResult Entry()
        {
            var model = new QuestionCreateVM()
            {
                OrganizationSelectListItems = GetAllOrganizationSlItems(),
                CourseSelectListItems = GetAllCourseSlItems(),
                ExamSelectListItems = GetAllExamSlItems()
            };
            return View(model);
        }


        public List<SelectListItem> GetAllExamSlItems()
        {
            var exams = _questionBankManager.GetAllExam();
            var slItems = new List<SelectListItem>();
            foreach (var exam in exams)
            {
                var sli = new SelectListItem();
                
                sli.Value = exam.Id.ToString();
                slItems.Add(sli);
            }
            return slItems;
        }
        public List<SelectListItem> GetAllCourseSlItems()
        {
            var courses = _questionBankManager.GetAllCourse();
            var slItems = new List<SelectListItem>();
            foreach (var course in courses)
            {
                var sli = new SelectListItem();
                sli.Text = course.Name + " - " + course.Code;
                sli.Value = course.Id.ToString();
                slItems.Add(sli);
            }
            return slItems;
        }
        public List<SelectListItem> GetAllOrganizationSlItems()
        {
            var organizations = _questionBankManager.GetAllOrganization();
            var slItems = new List<SelectListItem>();
            foreach (var organization in organizations)
            {
                var sli = new SelectListItem();
                sli.Text = organization.Name + " - " + organization.Code;
                sli.Value = organization.Id.ToString();
                slItems.Add(sli);
            }
            return slItems;
        }


    }
}