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
    public class LevelController : Controller
    {
        // GET: Level
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDataLevel()
        {

            using (LMSContext db = new LMSContext())
            {
                List<Level> levelList = db.Levels.ToList<Level>();
                return Json(new { data = levelList }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpGet]
        public ActionResult AddOrEditLevel(int id = 0)
        {

            if (id == 0)
                return View(new Level());
            else
            {
                using (LMSContext db = new LMSContext())
                {
                    return View(db.Levels.Where(x => x.ID == id).FirstOrDefault<Level>());
                }
            }

        }
        [HttpPost]
        public ActionResult AddOrEditLevel(Level lvl)
        {
            using (LMSContext db = new LMSContext())
            {
                if (lvl.ID == 0)
                {
                    db.Levels.Add(lvl);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Записът е успешен." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(lvl).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Редакцията е успешна." }, JsonRequestBehavior.AllowGet);
                }

            }

        }
        [HttpPost]
        public ActionResult DeleteLevel(int id)
        {
            using (LMSContext db = new LMSContext())
            {
                Level lvl = db.Levels.Where(x => x.ID == id).FirstOrDefault<Level>();
                db.Levels.Remove(lvl);
                db.SaveChanges();
                return Json(new { success = true, message = "Записът е изтрит." }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}