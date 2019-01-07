using AcademList.Models.DAOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademList.Controllers.DAOControllers
{
    public class DAOAcadListController : Controller
    {
        Entities entities = new Entities();

        DAOAcadList daoacadlist = new DAOAcadList();
        DAOPattern daopat = new DAOPattern();
        DAOAspNetUser daouser = new DAOAspNetUser();

        // GET: DAOAcadList
        public ActionResult Index()
        {
            return View(daoacadlist.GetAllAcadList());
        }

        [HttpGet]
        public ActionResult AcadListIndex(int id)
        {
            return View(daoacadlist.GetGroupAcadList(id));
        }

        [HttpPost]
        public ActionResult AcadListIndex()
        {
            int id = Convert.ToInt32(Request["id"]);
            return View(daoacadlist.GetGroupAcadList(id));
        }

        public ActionResult Create()
        {
            var user = daouser.GetAllUsers();
            ViewData["Student_Id"] = new SelectList(user, "Id", "Surname");

            var pat = daopat.GetAllPattern();
            ViewData["Pattern_Id"] = new SelectList(pat, "Id", "Number");
            
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] AcadList alist)
        {
            if (daoacadlist.AddAcadList(alist))
                return RedirectToAction("Index", "DAOPattern");
            else
            {
                return View("Create");
            }
        }

        public ActionResult Edit(int id)
        {
            return View(daoacadlist.GetAcadList(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, AcadList al)
        {
            if ((id > 0) && (al != null) && (ModelState.IsValid))
            {
                daoacadlist.UpdateAcadList(al);
                return RedirectToAction("ProffIndex", "DAOPattern");
            }
            else
            {
                return View("Edit");
            }
        }
    }
}