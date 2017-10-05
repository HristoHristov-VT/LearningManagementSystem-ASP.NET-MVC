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
    public class SubjectGradeController : Controller
    {
        // GET: SubjectGrade
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDataSubjectGrade()
        {

            using (LMSContext db = new LMSContext())
            {
                List<SubjectGrade> subgrdList = db.SubjectGrades.ToList<SubjectGrade>();
                return Json(new { data = subgrdList }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpGet]
        public ActionResult AddOrEditSubjectGrade(int id = 0)
        {

            if (id == 0)
                return View(new SubjectGrade());
            else
            {
                using (LMSContext db = new LMSContext())
                {
                    return View(db.SubjectGrades.Where(x => x.ID == id).FirstOrDefault<SubjectGrade>());
                }
            }

        }
        [HttpPost]
        public ActionResult AddOrEditSubjectGrade(SubjectGrade subgr)
        {
            using (LMSContext db = new LMSContext())
            {
                if (subgr.ID == 0)
                {
                    db.SubjectGrades.Add(subgr);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Записът е успешен." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(subgr).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Редакцията е успешна." }, JsonRequestBehavior.AllowGet);
                }

            }

        }
        [HttpPost]
        public ActionResult DeleteSubjectGrade(int id)
        {
            using (LMSContext db = new LMSContext())
            {
                SubjectGrade subgr = db.SubjectGrades.Where(x => x.ID == id).FirstOrDefault<SubjectGrade>();
                db.SubjectGrades.Remove(subgr);
                db.SaveChanges();
                return Json(new { success = true, message = "Записът е изтрит." }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}