using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using Vidly.Migrations;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies

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
            //var movies = _context.Movie.Include(m => m.Genre).ToList();

            return View();
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movie.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
        public ActionResult New()
        {
            var genres = _context.Genre.ToList();
            var viewModel = new MovieFormViewModel
            {
                ReleaseDate = DateTime.Now,
                NumberInStock =  0,
                Genres = genres
            };
            return View("MovieForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genre.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movie.Add(movie);
            }
               
            else
            {
                // SingleOrDefault() is not used;because if customer is not found, it will trow an exception
                var MovieInDb = _context.Movie.Include(g => g.Genre).Single(c => c.Id == movie.Id);

                MovieInDb.Name = movie.Name;
                MovieInDb.ReleasedDate = movie.ReleasedDate;
                MovieInDb.GenreId = movie.GenreId;
                MovieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movie.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genre.ToList()
            };
            return View("MovieForm", viewModel);
        }


        //[Route("movies/released/{year:regex(\\d{4}):range(2015,2016)}/{month:regex(\\d{2}):range(1,12)}")] //regex:Regular Expression
        //public ActionResult ByReleaseYear( int year, int month )
        //{
        //    return Content(year + "/" + month);
        //}

        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(string.Format("pageIndex={0}&sortBy={1}",pageIndex,sortBy));
        //}

        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}

    }
}