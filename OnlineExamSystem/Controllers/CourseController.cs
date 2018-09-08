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

        private OrganizationManager _organizationManager = new OrganizationManager();
        // GET: Course
        [HttpGet]
        public ActionResult Entry()
        {
            var organizations = _organizationManager.GetAllOrganization();
            ViewBag.OrganizationList = organizations.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Entry(Course course)
        {
            var organizations = _organizationManager.GetAllOrganization();
            if (ModelState.IsValid)
            {
                bool isAdded = _courseManager.Add(course);
                if (isAdded)
                {
                    ViewBag.Message = "Saved";
                    return RedirectToAction("Information", course);
                }
                else
                {
                    ViewBag.Message = "Failed";
                    ViewBag.OrganizationList = organizations.ToList();
                    return View();
                }
            }
            ModelState.AddModelError("","An Unknown Error Occured!");
            ViewBag.OrganizationList = organizations.ToList();
            return View();
        }

        public ActionResult Information(Course course)
        {
            var organizations = _organizationManager.GetAllOrganization();
            ViewBag.OrganizationList = organizations.ToList();
            return View();
        }
    }
}