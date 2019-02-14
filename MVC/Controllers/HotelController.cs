using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class HotelController : Controller
    {

        HotelRepository rep = new HotelRepository();
        // GET: Hotel
        public ActionResult Index()
        {
            return View(rep.FindAll());
        }

        public ActionResult Edit(int id)
        {
            ViewBag.SterneAuswahl = CreateSterne();
            return View(rep.FindById(id));
        }


        [HttpPost]
        public ActionResult Edit(Hotel hotel)
        {
            rep.Save(hotel);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            ViewBag.SterneAuswahl = CreateSterne();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Hotel hotel)
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
        public  ActionResult DeleteConfirmed(int id)
        {
            rep.Delete(id);
            return RedirectToAction(nameof(Index));
        }


        private IEnumerable<SelectListItem> CreateSterne()
        {
            List<HotelClassification> stars = new List<HotelClassification>
            {
                new HotelClassification(1, "Scheiss loch"),
                new HotelClassification(2, "auch scheisse"),
                new HotelClassification(3, "ok"),
                new HotelClassification(4, "good shit"),
                new HotelClassification(5, "HIGH END LUXURYOUS MOTHERFUCKING HOTEL")
            };
            return new SelectList(stars, "Stars", "Description");
        }

        class HotelClassification
        {

            public int Stars
            { get; set; }

            public string Description { get; set; }
            public HotelClassification(int stars, string text)
            {
                Stars = stars;
                Description = text;
            }
        }
    }
}