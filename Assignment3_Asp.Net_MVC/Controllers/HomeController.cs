using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment1_ASP.NET_MVC.Models;
using System.IO;

namespace Assignment1_ASP.NET_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["str1"] = "This is a String passed using viewData";
            ViewData["num1"] = 100;

            ViewBag.str2 = "This is a string passed using ViewBag";
            ViewBag.num2 = 200;
            return View();
        }

        public ActionResult AddUser()
        {
            return View();
        }

        public ActionResult SaveUser(User u)
        {
            StreamWriter sw = new StreamWriter(Server.MapPath("~/App_Data/users.txt"), true);
            sw.WriteLine("User details added on : " + DateTime.Now.ToString());
            sw.WriteLine("User Name : " + u.UserName);
            sw.WriteLine("Password : " + u.Password);
            sw.WriteLine();
            sw.Close();
            return Content("User details have been Saved!!");
        }

        //just for demonstration HtmlHelpers
        public ActionResult HtmlHelpers()
        {
            return View();
        }
    }
}