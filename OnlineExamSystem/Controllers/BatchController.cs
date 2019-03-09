using AutoMapper;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityModels;
using EntityModels.ViewModel.BatchVM;

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
                OrganizationSelectListItems = GetAllOrganizationSlItems(),
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
                var batches = _batchManager.GetAllBatches();
                if (batches.FirstOrDefault(x => x.Id == batch.Id) != null)
                {
                    ViewBag.Message = "Exist";
                    entity.OrganizationSelectListItems = GetAllOrganizationSlItems();
                    return View(entity);
                }
                else
                {
                    bool isAdded = _batchManager.Add(batch);
                    if (isAdded)
                    {
                        ViewBag.Message = "Saved";
                        return RedirectToAction("Edit", batch);
                    }
                }
            }

            ModelState.AddModelError("", "An Unknown Error Occured!");
            entity.OrganizationSelectListItems = GetAllOrganizationSlItems();
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
            entity.Trainers = _batchManager.GetTrainersByBatchId(entity.Id);
            entity.Participants = _batchManager.GetParticipantByBatchId(entity.Id);
            return View(entity);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BatchEditVm entity)
        {
            if (entity.ScheduleExams != null && entity.ScheduleExams.Count > 0 && entity.Trainers != null &&
                entity.Trainers.Count > 0 && entity.Participants != null &&
                entity.Participants.Count > 0)
            {
                if (ModelState.IsValid)
            {
                    bool isAdded = _batchManager.AddExamSchedule(entity.ScheduleExams);
                    bool isAssigned = _batchManager.AssignTrainers(entity.Trainers);
                    bool isEntered = _batchManager.AssignParticipants(entity.Participants);
                    if (isAssigned == true && isAdded == true)
                    {
                        var batch = Mapper.Map<Batch>(entity);
                        bool isUpdated = _batchManager.Update(batch);
                        if (isUpdated)
                        {
                            ViewBag.Message = "Updated";
                            return RedirectToAction("ViewInfo", batch);
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
            entity.ParticipantSelectListItems = GetAllParticipantSlItems();
            entity.TrainerSelectListItems = GetAllTrainersSlItems();
            entity.ExamSelectListItems = GetAllExamSlItems();
            return View("Edit", entity);
        }

        [HttpGet]
        public ActionResult ViewInfo(Batch batch)
        {
            var entity = Mapper.Map<BatchInformationVm>(batch);
            return View(entity);
        }
        public List<SelectListItem> GetAllOrganizationSlItems()
        {
            var organizations = _batchManager.GetAllOrganization();
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
        public JsonResult GetInfoByOrganizationId(int id)
        {
            if (id > 0)
            {
                var dataList = _batchManager.GetAllCourse().Where(x => x.OrganizationId == id).ToList();
                return Json(dataList);
            }
            return null;
        }
        //paste here
        public JsonResult GetInfoByParticipantId(int id)
        {
            if (id > 0)
            {
                var participants = _batchManager.GetParticipantById(id);
                return Json(participants);
            }
            return null;
        }

        public JsonResult GetInfoByTrainerId(int id)
        {
            if (id > 0)
            {
                var dataList = _batchManager.GetInfoByTrainerId(id);
                return Json(dataList);
            }
            return null;
        }

        public JsonResult GetExamById(int id)
        {
            if (id > 0)
            {
                var dataList = _batchManager.GetExamById(id);
                return Json(dataList);
            }
            return null;
        }
    }
}