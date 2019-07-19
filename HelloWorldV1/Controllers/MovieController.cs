using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldV1.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            using (var db = new Models.MovieDBContext())
            {
                var movies = db.Movies.ToList();
                return View(movies);
            }
        }
        [HttpGet]
        public ActionResult Add()
        {
            Models.Movie movie = new Models.Movie();
            return View(movie);
        }
        [HttpPost]
        public ActionResult Add(Models.Movie movieFromView)
        {
            using (var db = new Models.MovieDBContext())
            {
                db.Movies.Add(movieFromView);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}