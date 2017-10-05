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
    public class AttendanceController : Controller
    {
        // GET: Attendance
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDataAttendance()
        {

            using (LMSContext db = new LMSContext())
            {
                List<Attendance> attend = db.Attendances.ToList<Attendance>();
                return Json(new { data = attend }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpGet]
        public ActionResult AddOrEditAttendance(int id = 0)
        {

            if (id == 0)
                return View(new Attendance());
            else
            {
                using (LMSContext db = new LMSContext())
                {
                    return View(db.Attendances.Where(x => x.ID == id).FirstOrDefault<Attendance>());
                }
            }

        }
        [HttpPost]
        public ActionResult AddOrEditAttendance(Attendance attendance)
        {

            using (LMSContext db = new LMSContext())
            {
                if (attendance.ID == 0)
                {
                    var newAtendance = new Attendance();
                    newAtendance.Date = DateTime.Now;
                    newAtendance.Remark = "test";

                    var student = db.Students.ToList().FirstOrDefault();
                    newAtendance.Student = student;

                    db.Attendances.Add(newAtendance);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Записът е успешен." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(attendance).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Редакцията е успешна." }, JsonRequestBehavior.AllowGet);
                }

            }

        }
        [HttpPost]
        public ActionResult DeleteAttendance(int id)
        {
            using (LMSContext db = new LMSContext())
            {
                Attendance attendance = db.Attendances.Where(x => x.ID == id).FirstOrDefault<Attendance>();
                db.Attendances.Remove(attendance);
                db.SaveChanges();
                return Json(new { success = true, message = "Записът е изтрит." }, JsonRequestBehavior.AllowGet);
            }
        }
    }

   
}