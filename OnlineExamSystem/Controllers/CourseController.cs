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
            entity.Organization = _courseManager.GetOrganizationById(entity.OrganizationId);
            entity.TrainerSelectListItems = GetAllTrainersSlItems();
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseEditVm entity)
        {
             if (ModelState.IsValid)
                {
                    var course = Mapper.Map<Course>(entity);
                    bool isAdded = _courseManager.Update(course);
                    if (isAdded)
                    {
                        ViewBag.Message = "Updated";
                        return RedirectToAction("ViewInfo",course);
                    }
                    else
                    {
                        ViewBag.Message = "Failed";
                        return View("Edit",entity);
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
       
        public ActionResult ViewInfo(Course course)
        {
            var entity = Mapper.Map<CourseInformationVm>(course);
            entity.Organization = _courseManager.GetOrganizationById(entity.OrganizationId);
            ViewBag.Message = "Saved";
            return View(entity);
        }
        public List<SelectListItem> GetAllTrainersSlItems()
        {
            var trainers = _courseManager.GetAllOrganization();
            var slItems = new List<SelectListItem>();
            foreach (var trainer in trainers)
            {
                var sli = new SelectListItem();
                sli.Text = trainer.Name;
                sli.Value = trainer.Id.ToString();
                slItems.Add(sli);
            }
            return slItems;
        }
    }
}