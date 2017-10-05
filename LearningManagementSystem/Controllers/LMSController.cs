

namespace LearningManagementSystem.Controllers
{
    using LearningManagementSystem.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using LearningManagementSystem.Models;

    public class LMSController : Controller
    {
        // GET: LMS
        public ActionResult Index()
        {
            LMSContext context = new LMSContext();
            //context.Database.Initialize(true);
            //context.Students.Add(new Student() { FirstName = "Георги", LastName = "Георгиев" });
            //context.SaveChanges();

            return View();
        }
    }
}