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
    public class GradeParallelController : Controller
    {
        // GET: GradeParallel
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDataGradeParallel()
        {

            using (LMSContext db = new LMSContext())
            {
                List<GradeParallel> grdpList = db.GradeParallels.ToList<GradeParallel>();
                return Json(new { data = grdpList }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpGet]
        public ActionResult AddOrEditGradeParallel(int id = 0)
        {

            if (id == 0)
                return View(new GradeParallel());
            else
            {
                using (LMSContext db = new LMSContext())
                {
                    return View(db.GradeParallels.Where(x => x.ID == id).FirstOrDefault<GradeParallel>());
                }
            }

        }
        [HttpPost]
        public ActionResult AddOrEditGradeParallel(GradeParallel grd)
        {
            using (LMSContext db = new LMSContext())
            {
                if (grd.ID == 0)
                {
                    db.GradeParallels.Add(grd);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Записът е успешен." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(grd).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Редакцията е успешна." }, JsonRequestBehavior.AllowGet);
                }

            }

        }
        [HttpPost]
        public ActionResult DeleteGradeParallel(int id)
        {
            using (LMSContext db = new LMSContext())
            {
                GradeParallel grd = db.GradeParallels.Where(x => x.ID == id).FirstOrDefault<GradeParallel>();
                db.GradeParallels.Remove(grd);
                db.SaveChanges();
                return Json(new { success = true, message = "Записът е изтрит." }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}