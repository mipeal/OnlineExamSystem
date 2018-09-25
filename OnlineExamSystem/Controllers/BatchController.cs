using AutoMapper;
using BLL;
using Models.ViewModel.BatchVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.ViewModel.CourseVM;

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
            var entity = Mapper.Map<BatchEditVm>(batch);
            entity.Course = _batchManager.GetCourseById(entity.CourseId);
            entity.ParticipantSelectListItems = GetAllParticipantSlItems();
            entity.TrainerSelectListItems = GetAllTrainersSlItems();
            entity.ExamSelectListItems = GetAllExamSlItems();
            return View(entity);
        }

        [HttpGet]
        public ActionResult ViewInfo(Batch batch)
        {
            var entity = Mapper.Map<BatchInformationVm>(batch);
            return View(entity);
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

        public List<SelectListItem> GetAllTrainersSlItems()
        {
            var trainers = _batchManager.GetAllTrainers();
            var slItems = new List<SelectListItem>();
            foreach (var trainer in trainers)
            {
                var sli = new SelectListItem();
                sli.Text = trainer.Name + " - " + trainer.Code;
                sli.Value = trainer.Id.ToString();
                slItems.Add(sli);
            }

          return slItems;
        }


        public List<SelectListItem> GetAllParticipantSlItems()
        {
            var participants = _batchManager.GetAllParticipants();
            var slItems = new List<SelectListItem>();
            foreach (var participant in participants)
            {
                var sli = new SelectListItem();
                sli.Text = participant.Name + " - " + participant.RegNo;
                sli.Value = participant.Id.ToString();
                slItems.Add(sli);
            }

            return slItems;
        }
        public List<SelectListItem> GetAllExamSlItems()
        {
            var exams = _batchManager.GetAllExams();
            var slItems = new List<SelectListItem>();
            foreach (var exam in exams)
            {
                var sli = new SelectListItem();
                sli.Text = exam.Code + " - " + exam.Topic;
                sli.Value = exam.Id.ToString();
                slItems.Add(sli);
            }

            return slItems;
        }
    }
}