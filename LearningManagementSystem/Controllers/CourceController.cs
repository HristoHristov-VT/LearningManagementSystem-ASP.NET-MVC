using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningManagementSystem.Models;
using LearningManagementSystem.Data;
using System.Data.Entity;

namespace LearningManagementSystem.Controllers
{
    public class CourceController : Controller
    {
        // GET: Cource
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetDataCource()
        {

            using (LMSContext db = new LMSContext())
            {
                List<Cource> courseList = db.Cources.ToList<Cource>();
                return Json(new { data = courseList }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpGet]
        public ActionResult AddOrEditCource(int id = 0)
        {

            if (id == 0)
                return View(new Cource());
            else
            {
                using (LMSContext db = new LMSContext())
                {
                    return View(db.Cources.Where(x => x.ID == id).FirstOrDefault<Cource>());
                }
            }

        }
        [HttpPost]
        public ActionResult AddOrEditCource(Cource cource)
        {
            using (LMSContext db = new LMSContext())
            {
                if (cource.ID == 0)
                {
                    db.Cources.Add(cource);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Записът е успешен." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(cource).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Редакцията е успешна." }, JsonRequestBehavior.AllowGet);
                }

            }

        }
        [HttpPost]
        public ActionResult DeleteCource(int id)
        {
            using (LMSContext db = new LMSContext())
            {
                Cource std = db.Cources.Where(x => x.ID == id).FirstOrDefault<Cource>();
                db.Cources.Remove(std);
                db.SaveChanges();
                return Json(new { success = true, message = "Записът е изтрит." }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}