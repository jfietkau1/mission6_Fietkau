using Microsoft.AspNetCore.Mvc;
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
        public IActionResult addMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addMovie(Movie response)
        {


            response.lent_to ??= ""; // Set to empty string if null
            response.notes ??= "";
            response.edited ??= "";
            _movieContext.Movies.Add(response); //adds record to the database
            _movieContext.SaveChanges();


            return View("addMovieConfirmed",response);
        }









        public IActionResult viewMovies()
        {

            var movieData = _movieContext.Movies.ToList();
            return View(movieData);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
