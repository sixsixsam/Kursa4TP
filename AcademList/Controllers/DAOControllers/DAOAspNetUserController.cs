using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcademList.Models.DAOModels;

namespace AcademList.Controllers.DAOControllers
{
    public class DAOAspNetUserController : Controller
    {
        DAOAspNetUser daouser = new DAOAspNetUser();
        
        public ActionResult Index()
        {
            return View(daouser.GetAllUsers());
        }
        
        public ActionResult Details(int id)
        {
            return View();
        }
        
        public ActionResult Edit(string id)
        {
            return View(daouser.GetUser(id));
        }
        
        [HttpPost]
        public ActionResult Edit(string id, AspNetUsers anu)
        {
            if ((id != null) && (anu != null) && (ModelState.IsValid))
            {
                daouser.UpdateUser(anu);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit");
            }
        }

        public ActionResult Delete(string id)
        {
            return View("Delete", daouser.GetUser(id));
        }
        
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            if (id != null && ModelState.IsValid)
            {
                daouser.DeleteUser(id);
                return RedirectToAction("Index");
            }
            else
                return View();
        }
    }
}