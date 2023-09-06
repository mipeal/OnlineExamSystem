using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL;
using EntityModels;
using EntityModels.ViewModel.QuestionBankVM;

namespace OnlineExamSystem.Controllers
{
    public class QuestionBankController : Controller
    {
        QuestionBankManager _questionBankManager=new QuestionBankManager();
        [HttpGet]
        public ActionResult Entry()
        {
            var qOrder = _questionBankManager.GetQuestionOrder();
            var model = new QuestionCreateVM()
            {
                OrganizationSelectListItems = GetAllOrganizationSlItems(),
                TypeSelectListItems = GetOptionTypeSlItems(),
                Order = ++qOrder
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Entry(QuestionCreateVM entity)
        {
            if (ModelState.IsValid)
            {
                var question = Mapper.Map<QuestionBank>(entity);
                bool isAdded = _questionBankManager.Add(question);
                if (isAdded)
                {
                    ModelState.Clear();
                    var qOrder = _questionBankManager.GetQuestionOrder();
                    var model = new QuestionCreateVM()
                    {
                        OrganizationSelectListItems = GetAllOrganizationSlItems(),
                        TypeSelectListItems = GetOptionTypeSlItems(),
                        Order = ++qOrder
                    };
                    return View(model);
                }
            }
            ModelState.AddModelError("", "An Unknown Error Occured!");
            entity.OrganizationSelectListItems = GetAllOrganizationSlItems();
            entity.TypeSelectListItems = GetOptionTypeSlItems();
            return View(entity);
        }


        public JsonResult GetInfoByOrganizationId(int id)
        {
            if (id > 0)
            {
                var dataList = _questionBankManager.GetAllCourse().Where(x => x.OrganizationId == id).ToList();
                return Json(dataList);
            }
            return null;
        }
        public JsonResult GetAllQuestionByExamId(int id)
        {
            if (id > 0)
            {
                List<QuestionGridListVm> dataList = new List<QuestionGridListVm>();
                var questions = _questionBankManager.GetAllQuestions(id);
                foreach (var question in questions)
                {
                    var listItem = new QuestionGridListVm()
                    {
                        Order = question.Order,
                        Question = question.Question,
                        Type = question.Type,
                        Options = _questionBankManager.GetOptionsofQuestion(question.Id).Count
                    };
                    dataList.Add(listItem);
                }
                return Json(dataList);
            }
            return null;
        }
        public JsonResult GetInfoByCourseId(int id)
        {
            if (id > 0)
            {
                var dataList = _questionBankManager.GetAllExam().Where(x=>x.CourseId==id).ToList();
                return Json(dataList);
            }
            return null;
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


        public List<SelectListItem> GetOptionTypeSlItems()
        {
            var slItems = new List<SelectListItem>();
            var mcq = new SelectListItem()
            {
                Text = "Multiple Questions",
                Value = "MCQ"
            };
            var fig = new SelectListItem()
            {
                Text = "Fill in The Gaps",
                Value = "Fill In"
            };
            slItems.Add(mcq);
            slItems.Add(fig);
            return slItems;
        }
    }
}