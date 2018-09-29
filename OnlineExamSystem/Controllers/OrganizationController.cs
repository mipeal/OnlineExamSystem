using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

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
        public ActionResult Entry(Organization organization)
        {
            if (ModelState.IsValid)
            { 
                var organizations = _organizationManager.GetAllOrganization();
                if (organizations.FirstOrDefault(x => x.Code == organization.Code) != null)
                {
                    ViewBag.Message = "Exist";
                    return View(organization);
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
                return View();
            }
            ModelState.AddModelError("","An Unknown Error Occured!");
            return View();
        }
    }
}