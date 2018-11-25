using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeFood.Controllers
{
    public class CuisineController : Controller
    {
        // GET: Cuisine
        public ActionResult Search(string name = "French")
        {
            //! Server is a property that inherited in the controller that can be used to get to the server type utilities and variables including HtmlEncode.
            //! HtmlEncode: It makes sure if a user snuck through some sort of malicious script tag, it will render as text and it will prevent a cross-site scripting attack.
            //! Although razor view engine does this automatically but as Content result is used, the user input needed to be managed carefully.
            var message = Server.HtmlEncode(name);

            //x return RedirectToAction("Index", "Home", new { name });

            //! We don't pass the controller and action name with parameters, they have to be passed in an anonymously typed object
            //x return RedirectToRoute("Default", new { controller = "Home", action = "About" }); 

            //! Returns File Content. It also can be used to return files like PDF, text files, etc.. to be downloaded by the user
            //x return File(Server.MapPath("~/Content/site.css"), "text/css");

            //! Returns a serialized json to the response body
            return Json(new { Message = message, Name = "Sharaf" }, JsonRequestBehavior.AllowGet);
        }
    }
}