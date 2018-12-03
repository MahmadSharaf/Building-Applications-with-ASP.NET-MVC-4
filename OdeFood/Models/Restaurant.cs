using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeFood.Models
{
    public class Restaurant
    {
        public int    Id      { get ; set ; } 
        public string Name    { get ; set ; } 
        public string City    { get ; set ; } 
        public string Country { get ; set ; } 
        //! Virtual forces MVC to load the table as if it is not there a null exception will be thrown and virtual is one of many other solutions and the easiest one
        //! but it may affect the performance 
        public virtual ICollection<RestaurantReview> Reviews { get; set; }
        
    }
}   