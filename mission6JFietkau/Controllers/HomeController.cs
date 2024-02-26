using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mission6JFietkau.Models;
using System.Diagnostics;

namespace mission6JFietkau.Controllers
{
    public class HomeController : Controller
    {
        private movieContext _movieContext;

        public HomeController(movieContext temp) 
        {
            _movieContext = temp;
        }


        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult gettoknowjoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult addMovie(int? id)
        {

            if (id == null || id == 0)
            {
                ViewBag.Categories = _movieContext.Categories.ToList();
                // No ID was provided, this is a new movie scenario.
                var newMovie = new Movie();

                return View(newMovie);
            }
            else
            {
                // Fetch the movie from the database using the ID
                var movie = _movieContext.Movies.FirstOrDefault(x => x.MovieId == id);

                ViewBag.Categories = _movieContext.Categories.ToList();

                return View(movie);
            }
         }


        [HttpPost]
        public IActionResult addMovie(Movie response)
        {
            var catid = response.CategoryId;
            var movieiddd = response.MovieId;
            var ititle = response.Title;
            var iyear = response.Year;
            var ilentto = response.LentTo;
            var notes = response.Notes;
            var idirector = response.Director;
            var rating = response.Rating;
            var iedited = response.Edited;
            
            //var something = "something";

            if (ModelState.IsValid)
            {
                if (response.MovieId == 0)
                {
                    // This is a new movie
                    _movieContext.Movies.Add(response);
                    _movieContext.SaveChanges();
                }
                else 
                { 
                    var movieInDb = _movieContext.Movies.FirstOrDefault(m => m.MovieId == response.MovieId);
                    if (movieInDb != null)
                    {
                        movieInDb.CategoryId = response.CategoryId;
                        movieInDb.Title = response.Title;
                        movieInDb.Year = response.Year;
                        movieInDb.Director = response.Director;
                        movieInDb.Rating = response.Rating;
                        movieInDb.Edited = response.Edited;
                        movieInDb.LentTo = response.LentTo;
                        movieInDb.Notes = response.Notes;
                        // Update other properties as needed
                        _movieContext.SaveChanges();
                    }
                }   
                return RedirectToAction("viewMovies"); 
            }
            else
            {
                // If ModelState is not valid, return the view with the model to display validation errors
                ViewBag.Categories = _movieContext.Categories.ToList(); // Repopulate categories for the form
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                // You can inspect the 'errors' variable to see the validation messages.
                Console.WriteLine(errors);
                return View(response);
            }

        }





        public IActionResult EditMovie(int id)
        {
            // Retrieve and return the movie for editing
            


            return View("addMovie");
        }

        [HttpPost]
        public IActionResult DeleteMovie(int? id)
        {
            var movie = _movieContext.Movies.FirstOrDefault(x => x.MovieId == id);
            if (movie != null)
            {
                _movieContext.Movies.Remove(movie);
                _movieContext.SaveChanges();
                return RedirectToAction("ViewMovies"); // Assuming "ViewMovies" is the action that lists all movies
            }
            else
            {
                return RedirectToAction("Index");
            }
        }








        public IActionResult viewMovies()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            var movieData = _movieContext.Movies.Include(m => m.Category).ToList();
            return View(movieData);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
