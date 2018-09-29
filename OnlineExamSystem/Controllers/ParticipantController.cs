using BLL;
using Models;
using Models.ViewModel.ParticipantVM;
using Models.ViewModel.TrainerVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace OnlineExamSystem.Controllers
{
    public class ParticipantController : Controller
    {
        
     public ParticipantManager _participantManager = new ParticipantManager();      
             


        //GET: Participant
        [HttpGet]
        public ActionResult Entry()
        {
            var model = new ParticipantCreateVm()
            {
                OrganizationSelectListItems = GetAllOrganizationSlItems(),
                CourseSelectListItems = GetAllCourseSlItems(),
                BatchSelectListItems = GetAllBatchSlItems()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Entry(ParticipantCreateVm entity)
        {
            if (ModelState.IsValid)
            {
                var participant = Mapper.Map<Participant>(entity);
                var participants = _participantManager.GetAllParticipants();
                if (participants.FirstOrDefault(x => x.RegNo == participant.RegNo) != null)
                {
                    ViewBag.Message = "Exist";
                    entity.OrganizationSelectListItems = GetAllOrganizationSlItems();
                    entity.CourseSelectListItems = GetAllCourseSlItems();
                    entity.BatchSelectListItems = GetAllBatchSlItems();
                    return View(entity);
                }
                else
                {
                    bool isAdded = _participantManager.Add(participant);

                    if (isAdded)
                    {
                        ModelState.Clear();
                        ViewBag.Message = "Saved";
                        var model = new ParticipantCreateVm()
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
            var batches = _participantManager.GetAllBatch();
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
            var courses = _participantManager.GetAllCourse();
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
            var organizations = _participantManager.GetAllOrganization();
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