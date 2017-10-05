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
    public class AreaController : Controller
    {
        // GET: Area
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDataArea()
        {

            using (LMSContext db = new LMSContext())
            {
                List<Area> areasList = db.Areas.ToList<Area>();
                return Json(new { data = areasList }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public ActionResult AddOrEditArea(int id = 0)
        {

            if (id == 0)
                return View(new Area());
            else
            {
                using (LMSContext db = new LMSContext())
                {
                    return View(db.Areas.Where(x => x.ID == id).FirstOrDefault<Area>());
                }
            }

        }
        [HttpPost]
        public ActionResult AddOrEditArea(Area area)
        {
            using (LMSContext db = new LMSContext())
            {
                if (area.ID == 0)
                {
                    db.Areas.Add(area);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Записът е успешен." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(area).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Редакцията е успешна." }, JsonRequestBehavior.AllowGet);
                }

            }

        }
        [HttpPost]
        public ActionResult DeleteArea(int id)
        {
            using (LMSContext db = new LMSContext())
            {
                Area area = db.Areas.Where(x => x.ID == id).FirstOrDefault<Area>();
                db.Areas.Remove(area);
                db.SaveChanges();
                return Json(new { success = true, message = "Записът е изтрит." }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}