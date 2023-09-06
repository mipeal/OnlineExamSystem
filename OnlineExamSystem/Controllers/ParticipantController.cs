using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using EntityModels;
using EntityModels.ViewModel.ParticipantVM;

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
            HttpPostedFileBase file = Request.Files["uploadImage"];
            if (file != null)
            {
                entity.Image = ConvertToBytes(file);
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

        public JsonResult GetInfoByOrganizationId(int id)
        {
            if (id > 0)
            {
                var dataList = _participantManager.GetAllCourse().Where(x => x.OrganizationId == id).ToList();
                return Json(dataList);
            }
            return null;
        }
        public JsonResult GetInfoByCourseId(int id)
        {
            if (id > 0)
            {
                var dataList = _participantManager.GetAllBatch().Where(x => x.CourseId == id).ToList();
                return Json(dataList);
            }
            return null;
        }


        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        public string ConvertToJpgImage(byte[] imageBytes)
        {
            var base64 = Convert.ToBase64String(imageBytes);
            var imgSrc = string.Format("data:image/jpg;base64,{0}", base64);
            return imgSrc;
        }


        public string ConvertToPngImage(byte[] imageBytes)
        {
            var base64 = Convert.ToBase64String(imageBytes);
            var imgSrc = string.Format("data:image/png;base64,{0}", base64);
            return imgSrc;
        }
    }
}