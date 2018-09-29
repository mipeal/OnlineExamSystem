using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using EntityModels;
using EntityModels.ViewModel.TrainerVM;

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
                var trainers = _trainerManager.GetAllTrainers();
                if (trainers.FirstOrDefault(x => x.Code == trainer.Code) != null)
                {
                    ViewBag.Message = "Exist";
                    entity.OrganizationSelectListItems = GetAllOrganizationSlItems();
                    entity.CourseSelectListItems = GetAllCourseSlItems();
                    entity.BatchSelectListItems = GetAllBatchSlItems();
                    return View(entity);
                }
                else
                {
                    bool isAdded = _trainerManager.Add(trainer);
                    if (isAdded)
                    {
                        ModelState.Clear();
                        ViewBag.Message = "Saved";
                        var model = new TrainerCreateVm()
                        {
                            OrganizationSelectListItems = GetAllOrganizationSlItems(),
                            CourseSelectListItems = GetAllCourseSlItems(),
                            BatchSelectListItems = GetAllBatchSlItems()
                        };
                        return View(model);
                    }
                }
            }
            ModelState.AddModelError("", "An Unknown Error Occured!");
            entity.OrganizationSelectListItems = GetAllOrganizationSlItems();
            entity.CourseSelectListItems = GetAllCourseSlItems();
            entity.BatchSelectListItems = GetAllBatchSlItems();
            return View(entity);
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
        public JsonResult GetInfoByOrganizationId(int id)
        {
            if (id > 0)
            {
                var dataList = _trainerManager.GetAllCourse().Where(x => x.OrganizationId == id).ToList();
                return Json(dataList);
            }
            return null;
        }
        public JsonResult GetInfoByCourseId(int id)
        {
            if (id > 0)
            {
                var dataList = _trainerManager.GetAllBatch().Where(x => x.CourseId == id).ToList();
                return Json(dataList);
            }
            return null;
        }
    }
}