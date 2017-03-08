using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {        
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(c => c.GenreType).ToList();
            
            return View(movies);
        }
        
        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movies == null)
                return HttpNotFound();

            var ViewModel = new MovieViewModel
            {
                Movie = movies,
                GenreTypes = _context.Genres.ToList()
            };

            return View("MoviesForm", ViewModel);
        }

        public ActionResult New()
        {
            return View("MoviesForm");
        }

        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var moviesInDb = _context.Movies.Single(c => c.Id == movie.Id);

                moviesInDb.Name = movie.Name;
                //moviesInDb.Genre = movie.Genre;
                moviesInDb.ReleaseDate = movie.ReleaseDate;
                moviesInDb.DateAdded = movie.DateAdded;
                moviesInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Cancel()
        {
            return RedirectToAction("Index", "Movies");
        }
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Movie>
            {
                new Movie { Name = "Morgan" },
                new Movie { Name = "Therese" }
            };

            var ViewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(ViewModel);
        }

        // ASP.NET MVC Attribute Route Constraints
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        // movies
        
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}
    }
}