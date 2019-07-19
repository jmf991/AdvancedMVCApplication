using HelloWorldV1.Models;
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
            using (var db = new MovieDBContext())
            {
                var movies = db.Movies.ToList();
                return View(movies);
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            Models.Movie movie = new Movie();
            return View(movie);
        }

        [HttpPost]
        public ActionResult Add(Movie movieFromView)
        {
            if (ModelState.IsValid)
            {
                //Save the data in db and show the list of movies 
                using (var db = new MovieDBContext())
                {
                    db.Movies.Add(movieFromView);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(movieFromView);
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            using (var db = new MovieDBContext())
            {
                Movie movie = db.Movies.Find(id);
                // Find the movie from db 
                if (movie == null) // There is no movie with the passed id 
                {
                    return HttpNotFound();
                }
                return View(movie);
            }
        }

        [HttpPost]
        public ActionResult Edit(Movie movieToUpdate)
        {
            if (ModelState.IsValid)
            {
                //Update the data in db and show the list of movies 
                using (var db = new MovieDBContext())
                {
                    db.Entry(movieToUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(movieToUpdate);
        }
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            using (var db = new MovieDBContext())
            {
                Movie movie = db.Movies.Find(id);
                // Find the movie from db 
                if (movie == null) // There is no movie with the passed id 
                {
                    return HttpNotFound();
                }
                return View(movie);
            }
        }

        [HttpPost]
        public ActionResult Delete(Movie movieToDelete)
        {
            if (ModelState.IsValid)
            {
                //Update the data in db and show the list of movies 
                using (var db = new MovieDBContext())
                {
                    db.Entry(movieToDelete).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            return View(movieToDelete);
        }
    }
}