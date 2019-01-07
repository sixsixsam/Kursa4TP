using AcademList.Models.DAOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademList.Controllers.DAOControllers
{
    public class DAOSubjectController : Controller
    {
        Entities entities = new Entities();
        DAOSubject daosub = new DAOSubject();

        public ActionResult Index(int? page)
        {
            return View(daosub.GetAllSubject());
        }

        public ActionResult Details(int id)
        {
            return View(daosub.GetSubject(id));
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Subject subject)
        {
            if (daosub.AddSubject(subject))
                return RedirectToAction("Index");
            else
            {

                return View("Create");
            }
        }

        public ActionResult Edit(int id)
        {
            return View(daosub.GetSubject(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Subject subject)
        {
            if ((id > 0) && (subject != null) && (ModelState.IsValid))
            {
                daosub.UpdateSubject(subject);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit");
            }
        }

        public ActionResult Delete(int id)
        {
            return View("Delete", daosub.GetSubject(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (id > 0 && ModelState.IsValid)
            {
                daosub.DeleteSubject(id);
                return RedirectToAction("Index");
            }

            else return View();
        }
    }
}