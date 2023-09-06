using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using AutoMapper;
using BLL;
using EntityModels;
using EntityModels.ViewModel.OrganizationVM;

namespace OnlineExamSystem.Controllers
{
    public class OrganizationController : Controller
    {
        OrganizationManager _organizationManager = new OrganizationManager();
        // GET: Organization
        [HttpGet]
        public ActionResult Entry()
        {
            return View();
        }
        //POST: Organization
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Entry(OrganizationCreateVm entity)
        {
            HttpPostedFileBase file = Request.Files["uploadImage"];
            if (file != null)
            {
                entity.Logo = ConvertToBytes(file);
                if (ModelState.IsValid)
                {
                    var organization = Mapper.Map<Organization>(entity);
                    var organizations = _organizationManager.GetAllOrganization();
                    if (organizations.FirstOrDefault(x => x.Code == organization.Code) != null)
                    {
                        ViewBag.Message = "Exist";
                        return View(entity);
                    }
                    else
                    {
                        bool isAdded = _organizationManager.Add(organization);
                        if (isAdded)
                        {
                            ModelState.Clear();
                            ViewBag.Message = "Saved";;
                            return View();
                        }
                    }
                }
                else
                {
                    ViewBag.Message = "Failed";
                    return View(entity);
                }
            }
            
            ModelState.AddModelError("","An Unknown Error Occured!");
            return View(entity);
        }

        [HttpGet]
        public ActionResult ViewInfo(int id)
        {
            var organization = _organizationManager.GetOrganizationById(id);
            var entity = Mapper.Map<OrganizationInfoVm>(organization);
            entity.Logo = ConvertToJpgImage(organization.Logo);
            return View(entity);
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