using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class PersonController : Controller
    {
        PersonRepository rep = new PersonRepository();
        
        public ActionResult Index()
        {
            return View(rep.FindAll());
        }

        public ActionResult Edit(int id)
        {
            return View(rep.FindById(id));
        }


        [HttpPost]
        public ActionResult Edit(Person hotel)
        {
            rep.Save(hotel);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person hotel)
        {
            rep.Save(hotel);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Details(int id)
        {
            return View(rep.FindById(id));
        }

        public ActionResult Delete(int id)
        {
            return View(rep.FindById(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            rep.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
