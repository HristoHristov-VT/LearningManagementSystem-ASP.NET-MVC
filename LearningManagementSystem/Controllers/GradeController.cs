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
    public class GradeController : Controller
    {
        // GET: Grade
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDataGrade()
        {

            using (LMSContext db = new LMSContext())
            {
                List<Grade> grdList = db.Grades.ToList<Grade>();
                return Json(new { data = grdList }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpGet]
        public ActionResult AddOrEditGrade(int id = 0)
        {

            if (id == 0)
                return View(new Grade());
            else
            {
                using (LMSContext db = new LMSContext())
                {
                    return View(db.Grades.Where(x => x.ID == id).FirstOrDefault<Grade>());
                }
            }

        }
        [HttpPost]
        public ActionResult AddOrEditGrade(Grade grade)
        {
            using (LMSContext db = new LMSContext())
            {
                if (grade.ID == 0)
                {
                    db.Grades.Add(grade);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Записът е успешен." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(grade).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Редакцията е успешна." }, JsonRequestBehavior.AllowGet);
                }

            }

        }
        [HttpPost]
        public ActionResult DeleteGrade(int id)
        {
            using (LMSContext db = new LMSContext())
            {
                Grade grade = db.Grades.Where(x => x.ID == id).FirstOrDefault<Grade>();
                db.Grades.Remove(grade);
                db.SaveChanges();
                return Json(new { success = true, message = "Записът е изтрит." }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}