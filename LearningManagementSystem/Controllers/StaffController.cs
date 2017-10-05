
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

    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDataStaff()
        {

            using (LMSContext db = new LMSContext())
            {
                List<Staff> stfList = db.Staffs.ToList<Staff>();
                return Json(new { data = stfList }, JsonRequestBehavior.AllowGet);
            }



        }

        [HttpGet]
        public ActionResult AddOrEditStaff(int id = 0)
        {

            if (id == 0)
                return View(new Staff());
            else
            {
                using (LMSContext db = new LMSContext())
                {
                    return View(db.Staffs.Where(x => x.ID == id).FirstOrDefault<Staff>());
                }
            }

        }
        [HttpPost]
        public ActionResult AddOrEditStaff(Staff stf)
        {
            using (LMSContext db = new LMSContext())
            {
                if (stf.ID == 0)
                {
                    db.Staffs.Add(stf);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Записът е успешен." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(stf).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Редакцията е успешна." }, JsonRequestBehavior.AllowGet);
                }

            }

        }
        [HttpPost]
        public ActionResult DeleteStaff(int id)
        {
            using (LMSContext db = new LMSContext())
            {
                Staff stf = db.Staffs.Where(x => x.ID == id).FirstOrDefault<Staff>();
                db.Staffs.Remove(stf);
                db.SaveChanges();
                return Json(new { success = true, message = "Записът е изтрит." }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}