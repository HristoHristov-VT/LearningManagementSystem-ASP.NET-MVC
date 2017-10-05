
namespace LearningManagementSystem.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using LearningManagementSystem.Models;
    using LearningManagementSystem.Data;
    using System.Data.Entity;

    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDataSubject()
        {

            using (LMSContext db = new LMSContext())
            {
                List<Subject> subList = db.Subjects.ToList<Subject>();
                return Json(new { data = subList }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpGet]
        public ActionResult AddOrEditSubject(int id = 0)
        {

            if (id == 0)
                return View(new Subject());
            else
            {
                using (LMSContext db = new LMSContext())
                {
                    return View(db.Subjects.Where(x => x.ID == id).FirstOrDefault<Subject>());
                }
            }

        }
        [HttpPost]
        public ActionResult AddOrEditSubject(Subject sub)
        {
            using (LMSContext db = new LMSContext())
            {
                if (sub.ID == 0)
                {
                    db.Subjects.Add(sub);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Записът е успешен." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(sub).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Редакцията е успешна." }, JsonRequestBehavior.AllowGet);
                }

            }

        }
        [HttpPost]
        public ActionResult DeleteSubject(int id)
        {
            using (LMSContext db = new LMSContext())
            {
                Subject sub = db.Subjects.Where(x => x.ID == id).FirstOrDefault<Subject>();
                db.Subjects.Remove(sub);
                db.SaveChanges();
                return Json(new { success = true, message = "Записът е изтрит." }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}