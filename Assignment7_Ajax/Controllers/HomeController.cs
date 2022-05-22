using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment7Ajax.Models;

namespace Assignment7Ajax.Controllers
{
    public class HomeController : Controller
    {
        static List<User> users = new List<User>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetServerTime() //added
        {
            System.Threading.Thread.Sleep(5000);
            return PartialView();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult GetAllUsers()
        {
            return PartialView(users);
        }
        public ActionResult CreateUser() //to create data
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User u)  //to store data
        {
            users.Add(u);
            return RedirectToAction("GetAllUsers");
        }



    }
}