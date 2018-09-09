using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace OnlineExamSystem.Controllers
{
    public class CourseController : Controller
    {
        private CourseManager _courseManager = new CourseManager();
        // GET: Course
        [HttpGet]
        public ActionResult Entry()
        {
            Course course = new Course();
            course.OrganizationSelectListItems = GetAllOrganization();
            return View(course);
        }

        [HttpPost]
        public ActionResult Entry(Course course)
        {
            course.OrganizationSelectListItems = GetAllOrganization();
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
        public ActionResult Edit(Course course)
        {
            course.OrganizationSelectListItems = GetAllOrganization();
            return View(course);
        }

        [HttpPost]
        public ActionResult Edit(Course course, string status)
        {
            course.OrganizationSelectListItems = GetAllOrganization();
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

        public List<SelectListItem> GetAllOrganization()
        {
            var organizations = _courseManager.GetAllOrganization();
            var slItems = new List<SelectListItem>();
            foreach (var organization in organizations)
            {
                var sli = new SelectListItem
                {
                    Text = organization.Name + " - " + organization.Code,
                    Value = organization.Id.ToString()
                };
                slItems.Add(sli);
            }
            return slItems;
        }
        //public JsonResult GetAllOrganization()
        //{
        //    var organizations = _courseManager.GetAllOrganization();
        //    return Json(organizations);
        //}
    }
}