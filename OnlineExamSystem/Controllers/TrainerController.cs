using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.ViewModel.TrainerVM;
using Models;
using AutoMapper;

namespace OnlineExamSystem.Controllers
{
    public class TrainerController : Controller
    {
        TrainerManager _trainerManager = new TrainerManager();
        // GET: Trainer
        [HttpGet]
        public ActionResult Entry()
        {
            var model = new TrainerCreateVm()
            {
                OrganizationSelectListItems = GetAllOrganizationSlItems(),
                CourseSelectListItems = GetAllCourseSlItems(),
                BatchSelectListItems = GetAllBatchSlItems()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Entry(TrainerCreateVm entity)
        {
            if (ModelState.IsValid)
            {
                var trainer = Mapper.Map<Trainer>(entity);
                bool isAdded = _trainerManager.Add(trainer);
                if (isAdded)
                {
                    ViewBag.Message = "Saved";
                    return RedirectToAction("Edit", trainer);
                }
            }
            ModelState.AddModelError("", "An Unknown Error Occured!");
            return View(entity);
        }
        [HttpGet]
        public ActionResult Edit(Trainer trainer)
        {
            return View();
        }
        public List<SelectListItem> GetAllBatchSlItems()
        {
            var batches = _trainerManager.GetAllBatch();
            var slItems = new List<SelectListItem>();
            foreach (var batch in batches)
            {
                var sli = new SelectListItem();
                sli.Text = batch.No;
                sli.Value = batch.Id.ToString();
                slItems.Add(sli);
            }
            return slItems;
        }
        public List<SelectListItem> GetAllCourseSlItems()
        {
            var courses = _trainerManager.GetAllCourse();
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
            var organizations = _trainerManager.GetAllOrganization();
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