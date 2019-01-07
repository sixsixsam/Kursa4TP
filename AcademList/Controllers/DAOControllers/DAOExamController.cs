using AcademList.Models.DAOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademList.Controllers.DAOControllers
{
    public class DAOExamController : Controller
    {
        DAOExam daoex = new DAOExam();

        public ActionResult Edit(int id)
        {
            return View(daoex.GetExam(id));
        }

        [HttpPost]
        public ActionResult Edit(Exam ex)
        {
            int id = Convert.ToInt32(Request["id"]);

            if ((id > 0) && (ex != null) && (ModelState.IsValid))
            {
                daoex.UpdateExam(ex);
                return RedirectToAction("ProffIndex", "DAOPattern");
            }
            else
            {
                return View("Edit");
            }
        }
    }
}