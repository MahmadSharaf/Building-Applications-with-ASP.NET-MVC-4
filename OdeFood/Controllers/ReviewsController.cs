using OdeFood.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OdeFood.Controllers
{
    public class ReviewsController : Controller
    {
        //x [ChildActionOnly] //! Makes this action not accessible directly through a URL
        //x public ActionResult BestReview()
        //x {
        //x     var bestReview = from r in _reviews
        //x                      orderby r.Rating descending
        //x                      select r;
        //x     return PartialView("_Review", bestReview.First());
        //x }


        OdeToFoodDb _db = new OdeToFoodDb();
        
        // GET: Reviews
        //! Bind tells the MVC binder that when it is going to look for restaurantId parameter value
        //! look for something called Id
        public ActionResult Index([Bind(Prefix ="id")] int restaurantId)
        {
            var restaurant = _db.Restaurants.Find(restaurantId);
            if (restaurant != null)
            {
                return View(restaurant);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View(review);
        }

        [HttpGet]
        public ActionResult Edit(int restaurantId, int id)
        {
            if (id == null || restaurantId == null) //! Checks if the params are sent in the request
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); //! returns BadRequest
            }
            var review = _db.Reviews.Find(id); 
            if (review == null)
            {
                return HttpNotFound(); 
            }
            return View(review); 
        }

        [HttpPost]
        public ActionResult Edit(RestaurantReview review)
        {
            if (ModelState.IsValid) //! Makes sure all binding parameters and its validations are valid
            {
                _db.Entry(review).State = EntityState.Modified; //! apply the modified values in the entity
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View(review); //! If ModelState is false, return to the user the review again to correct the errors.
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
