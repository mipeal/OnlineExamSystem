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
                    return RedirectToAction("Edit", _batchManager);
                }
            }
            ModelState.AddModelError("", "An Unknown Error Occured!");
            return View(entity);
        }
        #endregion
    }
}