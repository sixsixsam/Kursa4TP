using AcademList.Models.DAOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademList.Controllers.DAOControllers
{
    public class DAOGroupsController : Controller
    {
        Entities entities = new Entities();
        DAOGroups daogroup = new DAOGroups();

        public ActionResult Index(int? page)
        {
            return View(daogroup.GetAllGroups());
        }

        public ActionResult Details(int id)
        {
            return View(daogroup.GetGroups(id));
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Groups groups)
        {
            if (daogroup.AddGroups(groups))
                return RedirectToAction("Index");
            else
            {

                return View("Create");
            }
        }

        public ActionResult Edit(int id)
        {
            return View(daogroup.GetGroups(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Groups groups)
        {
            if ((id > 0) && (groups != null) && (ModelState.IsValid))
            {
                daogroup.UpdateGroups(groups);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit");
            }
        }

        public ActionResult Delete(int id)
        {
            return View("Delete", daogroup.GetGroups(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (id > 0 && ModelState.IsValid)
            {
                daogroup.DeleteGroups(id);
                return RedirectToAction("Index");
            }

            else return View();
        }
    }
}