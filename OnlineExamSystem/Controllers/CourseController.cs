using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL;
using Models;
using Models.ViewModel.CourseVM;

namespace OnlineExamSystem.Controllers
{
    public class CourseController : Controller
    {
        private CourseManager _courseManager = new CourseManager();
        // GET: Course

        #region Course Entry

        [HttpGet]
        public ActionResult Entry()
        {
            var model = new CourseCreateVm()
            {
                OrganizationSelectListItems = GetAllOrganizationSlItems(),
                //TagsSelectListItems = GetAllTagsSlItems()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Entry(CourseCreateVm entity)
        {
            if (ModelState.IsValid)
            {
                var course = Mapper.Map<Course>(entity);
                bool isAdded = _courseManager.Add(course);
                if (isAdded)
                {
                    ViewBag.Message = "Saved";
                    return RedirectToAction("Edit", course);
                }
            }
            ModelState.AddModelError("","An Unknown Error Occured!");
            entity.OrganizationSelectListItems = GetAllOrganizationSlItems();
            //entity.TagsSelectListItems = GetAllTagsSlItems();
            return View(entity);
        }

            #endregion
        [HttpGet]
        public ActionResult Edit(Course course)

        {
            var entity = Mapper.Map<CourseEditVm>(course);
            var examSerial = _courseManager.ExamCounter();
            entity.Organization = _courseManager.GetOrganizationById(entity.OrganizationId);
            entity.TrainerSelectListItems = GetAllTrainersSlItems();
            entity.ExamSerial = ++examSerial;
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseEditVm entity)
        {
            foreach (var exam in entity.Exams)
            {
                exam.CourseId = entity.Id;
                exam.ExamCreated = DateTime.Now;
            }
            foreach (var trainer in entity.Trainers)
            {
                trainer.CourseId = entity.Id;
            }
            if (ModelState.IsValid)
             {
                 if (entity.Exams != null && entity.Exams.Count > 0 && entity.Trainers != null &&
                     entity.Trainers.Count > 0)
                 {
                     bool isAdded = _courseManager.AddExam(entity.Exams);
                     bool isAssigned = _courseManager.AssignTrainers(entity.Trainers);
                     if (isAssigned==true && isAdded == true)
                     {
                        var course = Mapper.Map<Course>(entity);
                         bool isUpdated = _courseManager.Update(course);
                         if (isUpdated)
                         {
                             ViewBag.Message = "Updated";
                             return RedirectToAction("ViewInfo", course);
                         }
                         else
                         {
                             ViewBag.Message = "Failed";
                             return View("Edit", entity);
                         }
                    }
                 }
                   
                }
            ModelState.AddModelError("", "An Unknown Error Occured!");
            return View("Edit",entity);
        }

        public List<SelectListItem> GetAllOrganizationSlItems()
        {
            var organizations = _courseManager.GetAllOrganization();
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
       [HttpGet]
        public ActionResult ViewInfo(Course course)
        {
            var entity = Mapper.Map<CourseInformationVm>(course);
            entity.Organization = _courseManager.GetOrganizationById(entity.OrganizationId);
            ViewBag.Message = "Saved";
            return View(entity);
        }
        public List<SelectListItem> GetAllTrainersSlItems()
        {
            var trainers = _courseManager.GetAllTrainers();
            var slItems = new List<SelectListItem>();
            foreach (var trainer in trainers)
            {
                var sli = new SelectListItem();
                sli.Text = trainer.Name;
                sli.Value =trainer.Id.ToString();
                slItems.Add(sli);
            }
            return slItems;
        }

        public JsonResult GetAllTrainers()
        {
            var trainers = _courseManager.GetAllTrainers();
            return Json(trainers);
        }
        public JsonResult GetInfoByTrainerId(int id)
        {
            if (id > 0)
            {
                var dataList = _courseManager.GetInfoByTrainerId(id);
                return Json(dataList);
            }
            return null;
        }

    }
}