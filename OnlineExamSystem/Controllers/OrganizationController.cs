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
        public ActionResult Entry(OrganizationCreateVm entity, List<HttpPostedFileBase> uploadFiles)
        {
            if (uploadFiles!=null && uploadFiles.Count>0 && uploadFiles[0]!=null)
            {
                
            }
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
                        ViewBag.Message = "Saved";
                        return View();
                    }
                }
            }
            else
            {
                ViewBag.Message = "Failed";
                return View(entity);
            }
            ModelState.AddModelError("","An Unknown Error Occured!");
            return View(entity);
        }
    }
}