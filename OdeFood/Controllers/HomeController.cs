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
        OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Index(string searchTerm = null)
        {
            var model = from r in _db.Restaurants
                        orderby r.Reviews.Average(s => s.Rating) descending
                        where searchTerm == null || r.Name.StartsWith(searchTerm)
                        select new RestaurantListViewModel{
                            Id             = r . Id      ,           
                            Name           = r . Name    ,           
                            City           = r . City    ,           
                            Country        = r . Country ,           
                            CountOfReviews = r . Reviews . Count ( ) 
                        };

            return View(model);
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

        protected override void Dispose(bool disposing)
        {
            if(_db != null) //! This is just a way to clean up resources that might be open
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

//? There are a couple of ways to get information to the view. 
//* One approach is to put information in "ViewBag.Message()". "ViewBag" is a dynamically typed object in C Sharp.
// That means any sort of property can be put to ViewBag and it will be available inside of the view to pull out and retrieve and display.
//* Another approach is using models 