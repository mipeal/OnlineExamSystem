using AutoMapper;
using BLL;
using Models.ViewModel.BatchVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace OnlineExamSystem.Controllers
{
    public class BatchController : Controller
    {
        private BatchManager _batchManager = new BatchManager();
        // GET: Batch

        #region Batch Entry

        [HttpGet]
        public ActionResult Entry()
        {
            var model = new BatchCreateVm()
            {
                CourseSelectListItems = GetAllCourseSlItems(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Entry(BatchCreateVm entity)
        {
            if (ModelState.IsValid)
            {
                var batch = Mapper.Map<Batch>(entity);
                bool isAdded = _batchManager.Add(batch);
                if (isAdded)
                {
                    ViewBag.Message = "Saved";
                    return RedirectToAction("Edit", batch);
                }
            }
            ModelState.AddModelError("", "An Unknown Error Occured!");
            return View(entity);
        }
        #endregion
        [HttpGet]
        public ActionResult Edit(Batch batch)
        {

            return View(batch);
        }
        public List<SelectListItem> GetAllCourseSlItems()
        {
            var courses = _batchManager.GetAllCourse();
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
    }
}