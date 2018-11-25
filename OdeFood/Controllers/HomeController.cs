using OdeFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeFood.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var id = RouteData.Values["id"];

            var message = String.Format("{0}::{1} {2}", controller, action, id);

            ViewBag.Message = message;

            return View();
        }

        public ActionResult About()
        {
            //? First approach uses ViewBag
            //ViewBag.Message = "Your application description page.";
            //ViewBag.Location = "Cairo/Egypt"; // passes to the view "Cairo/Egypt" through "Location" property.
            //return View();

            //? Second approach uses Model
            var model = new AboutModel
            {
                Name     = "Sharaf"       , 
                Location = "Cairo, Egypt"   
            };
            return View(model); //sends the Model object "model" to the view
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

//? There are a couple of ways to get information to the view. 
//* One approach is to put information in "ViewBag.Message()". "ViewBag" is a dynamically typed object in C Sharp.
// That means any sort of property can be put to ViewBag and it will be available inside of the view to pull out and retrieve and display.
//* Another approach is using models 