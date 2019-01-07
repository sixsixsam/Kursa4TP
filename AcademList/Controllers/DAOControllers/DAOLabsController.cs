using AcademList.Models.DAOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademList.Controllers.DAOControllers
{
    public class DAOLabsController : Controller
    {
        DAOLabs daolabs = new DAOLabs();

        public ActionResult Edit(int id)
        {
            return View(daolabs.GetLabs(id));
        }

        [HttpPost]
        public ActionResult Edit( Labs l)
        {
            int id = Convert.ToInt32(Request["id"]);

            if ((id > 0) && (l != null) && (ModelState.IsValid))
            {
                daolabs.UpdateLabs(l);
                return RedirectToAction("ProffIndex", "DAOPattern");
            }
            else
            {
                return View("Edit");
            }
        }
    }
}