using DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepository;

        public MovieController(IMovieRepository _movieRepository)
        {
            movieRepository = _movieRepository;
        }
        public IActionResult Index()
        {
            ViewBag.Movies = movieRepository.GetMovies();

            return View(movieRepository.GetMovies());
        }



        public IActionResult AddMovie()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            try
            {
                movieRepository.AddMovie(movie);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return View();

            }
        }


        public IActionResult DeleteMovie(int id)
        {
            movieRepository.Deletemovie(id);
            return View();

        }


        public IActionResult UpdateMovie(int id)
        {
            {
                return View(movieRepository.Where(x => x.Id == id).FirstOrDefault());


            }

        }

        [HttpPost]
        public IActionResult UpdateMovie(Movie movie)
        {
            movieRepository.Updatemovie(movie);
            return RedirectToAction("Index");
        }
    }
}
