using AcademList.Models.DAOModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademList.Controllers.DAOControllers
{
    public class DAOPatternController : Controller
    {
        DAOPattern daopattern = new DAOPattern();
        DAOAspNetUser daouser = new DAOAspNetUser();
        DAOSubject daosub = new DAOSubject();
        DAOGroups daogr = new DAOGroups();

        // GET: DAOPattern
        public ActionResult Index()
        {
            return View(daopattern.GetAllPattern());
        }

        public ActionResult ProffIndex()
        {
            string id = User.Identity.GetUserId();
            return View(daopattern.GetUserPattern(id));
        }

        public ActionResult Edit(int id)
        {
            return View(daopattern.GetPattern(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Pattern pat)
        {
            if ((id > 0) && (pat != null) && (ModelState.IsValid))
            {
                daopattern.UpdatePattern(pat);
                return RedirectToAction("ProffIndex");
            }
            else
            {
                return View("Edit");
            }
        }

        public ActionResult Create()
        {
            var user = daouser.GetAllUsers();
            ViewData["Professor_Id"] = new SelectList(user, "Id", "Surname");

            var sub = daosub.GetAllSubject();
            ViewData["Subject_Id"] = new SelectList(sub, "Id", "SubjectName");

            var group = daogr.GetAllGroups();
            ViewData["Group_Id"] = new SelectList(group, "Id", "GroupName");

            return View("Create");
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Pattern pat)
        {
            if (daopattern.AddPattern(pat))
                return RedirectToAction("Index");
            else
            {
                return View("Create");
            }
        }
    }
}