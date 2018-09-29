using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL;
using Models;
using Models.ViewModel.ExamVM;
using Models.ViewModel.TrainerVM;

namespace OnlineExamSystem.Controllers
{
    public class ExamController : Controller
    {
        private ExamManager _examManager = new ExamManager();
        // GET: Exam
        [HttpGet]
        public ActionResult Entry()
        {

            var examSerial = _examManager.ExamCounter();
            var model = new ExamCreateVm()
            {
                ExamTypeSelectListItems = GetAllExamTypesSLI(),
                OrganizationSelectListItems = GetAllOrganizationSlI(),
                Serial = ++examSerial
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Entry(ExamCreateVm entity)
        {
            if (ModelState.IsValid)
            {
                var exam = Mapper.Map<Exam>(entity);
                var exams = _examManager.GetAllExams();
                if (exams.FirstOrDefault(x => x.Code == exam.Code) != null)
                {
                    ViewBag.Message = "Exist";
                    entity.ExamTypeSelectListItems = GetAllExamTypesSLI();
                    entity.OrganizationSelectListItems = GetAllOrganizationSlI();
                    return View(entity);
                }
                else
                {
                    bool isAdded = _examManager.Add(exam);
                    if (isAdded)
                    {
                        ModelState.Clear();
                        ViewBag.Message = "Saved";
                        var examSerial = _examManager.ExamCounter();
                        var model = new ExamCreateVm()
                        {
                            ExamTypeSelectListItems = GetAllExamTypesSLI(),
                            OrganizationSelectListItems = GetAllOrganizationSlI(),
                            Serial = ++examSerial
                        };
                        return View(model);
                    }
                }
            }
            ModelState.AddModelError("", "An Unknown Error Occured!");
            entity.ExamTypeSelectListItems = GetAllExamTypesSLI();
            entity.OrganizationSelectListItems = GetAllOrganizationSlI();
            return View(entity);
        }


        public List<SelectListItem> GetAllOrganizationSlI()
        {
            var organizations = _examManager.GetAllOrganization();
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


        private List<SelectListItem> GetAllExamTypesSLI()
        {
            var slItems = new List<SelectListItem>();
            var classType = new SelectListItem()
            {
                Text = "Class",
                Value = "Class"
            };
            var labType = new SelectListItem()
            {
                Text = "Lab",
                Value = "Lab"
            };
            slItems.Add(classType);
            slItems.Add(labType);
            return slItems;
        }
        public JsonResult GetInfoByCourseId(int id)
        {
            if (id > 0)
            {
                var dataList = _examManager.GetInfoByCourseId(id);
                return Json(dataList);
            }
            return null;
        }
    }
}