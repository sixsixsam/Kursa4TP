using AcademList.Models.DAOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademList.Controllers.DAOControllers
{
    public class DAORatingController : Controller
    {
        DAORating daorat = new DAORating();

        public ActionResult Edit(int id)
        {
            return View(daorat.GetRating(id));
        }

        [HttpPost]
        public ActionResult Edit(Rating r)
        {
            int id = Convert.ToInt32(Request["id"]);

            if ((id > 0) && (r != null) && (ModelState.IsValid))
            {
                daorat.UpdateRating(r);
                return RedirectToAction("ProffIndex", "DAOPattern");
            }
            else
            {
                return View("Edit");
            }
        }
    }
}