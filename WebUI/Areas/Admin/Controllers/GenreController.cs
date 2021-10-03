using DataAccess.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    [Authorize]

    [Area("Admin")]
    public class GenreController : Controller
    {
        private readonly IGenreRepository genreRepository;

        public GenreController(IGenreRepository _genreRepository)
        {
            genreRepository = _genreRepository;
        }


        public IActionResult Index()
        {
            return View(genreRepository.GetGenres());
        }

        public IActionResult AddGenre()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddGenre(Genre genre)
        {
            try
            {
                genreRepository.PostGenre(genre);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

               return View();
            }
        }


        public IActionResult DeleteGenre(int id)
        {
            genreRepository.DeleteGenre(id);
            return View();

        }



        public IActionResult UpdateGenre(int id)
        {
            {
                return View(genreRepository.Where(x => x.Id == id).FirstOrDefault());


            }

        }

        [HttpPost]
        public IActionResult UpdateGenre(Genre genre)
        {
            genreRepository.UpdateGenre(genre);
            return RedirectToAction("Index");
        }


    }
}
