using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using OnlineExamSystem.Models.CourseVM;

namespace OnlineExamSystem.Controllers
{
    public class CourseController : Controller
    {
        private CourseManager _courseManager = new CourseManager();
        // GET: Course
        [HttpGet]
        public ActionResult Entry()
        {
            var model = new CourseCreateVm()
            {
                OrganizationSelectListItems = GetAllOrganizationSLI(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Entry(Course entity)
        {
            var course = new Course()
            {
                Name = entity.Name,
                Code = entity.Code,
                Duration = entity.Duration,
                Credit = entity.Credit,
                Fees = entity.Fees,
                Outline = entity.Outline,
                OrganizationId = entity.OrganizationId
            };
            if (ModelState.IsValid)
            {
                bool isAdded = _courseManager.Add(course);
                if (isAdded)
                {
                    ViewBag.Message = "Saved";
                    return RedirectToAction("Edit", course);
                }
            }
            ModelState.AddModelError("","An Unknown Error Occured!");
            return View();
        }
        [HttpGet]
        public ActionResult Edit(CourseCreateVm entity)
        {
            var course = new Course()
            {
                Name = entity.Name,
                Code = entity.Code,
                Duration = entity.Duration,
                Credit = entity.Credit,
                Fees = entity.Fees,
                Outline = entity.Outline,
                OrganizationId = entity.OrganizationId
            };
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course entity, string status)
        {
            var course = new Course()
            {
                Name = entity.Name,
                Code = entity.Code,
                Duration = entity.Duration,
                Credit = entity.Credit,
                Fees = entity.Fees,
                Outline = entity.Outline,
                OrganizationId = entity.OrganizationId
            };
            if (status == "update")
            {
                if (ModelState.IsValid)
                {
                    bool isAdded = _courseManager.Update(course);
                    if (isAdded)
                    {
                        ViewBag.Message = "Updated";
                        return View(course);
                    }
                    else
                    {
                        ViewBag.Message = "Failed";
                        return View(course);
                    }
                }
            }
            ModelState.AddModelError("", "An Unknown Error Occured!");
            return View(course);
        }
        public JsonResult GetAllOrganization()
        {
            var organizations = _courseManager.GetAllOrganization();
            return Json(organizations,JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllTrainers()
        {
            var trainers = _courseManager.GetAllTrainers();
            return Json(trainers, JsonRequestBehavior.AllowGet);
        }


        public List<SelectListItem> GetAllOrganizationSLI()
        {
            var organizations = _courseManager.GetAllOrganization();

            var slItems = new List<SelectListItem>();
            foreach (var organization in organizations)
            {
                var sli = new SelectListItem();
                sli.Text = organization.Name + " " + organization.Code;
                sli.Value = organization.Id.ToString();

                slItems.Add(sli);
            }

            return slItems;
        }
}
}