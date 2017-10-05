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
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetData()
        {

            using (LMSContext db = new LMSContext())
            {
                List<Student> stList = db.Students.ToList<Student>();
                return Json(new { data = stList }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            
            if (id == 0)
                return View(new Student());
            else
            {
                using (LMSContext db = new LMSContext())
                {
                    return View(db.Students.Where(x => x.ID == id).FirstOrDefault<Student>());
                }
            }

        }
        [HttpPost]
        public ActionResult AddOrEdit(Student std)
        {
            using (LMSContext db = new LMSContext())
            {
                if (std.ID == 0)
                {
                    db.Students.Add(std);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Записът е успешен." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(std).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Редакцията е успешна." }, JsonRequestBehavior.AllowGet);
                }

            }

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (LMSContext db = new LMSContext())
            {
                Student std = db.Students.Where(x => x.ID == id).FirstOrDefault<Student>();
                db.Students.Remove(std);
                db.SaveChanges();
                return Json(new { success = true, message = "Записът е изтрит." }, JsonRequestBehavior.AllowGet);
            }
        }






    }
}