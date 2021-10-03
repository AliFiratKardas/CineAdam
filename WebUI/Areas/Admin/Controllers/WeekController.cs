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

    public class WeekController : Controller
    {
        private readonly IWeekRepository weekRepository;
        public WeekController(IWeekRepository _weekRepository)
        {
            weekRepository = _weekRepository;
        }



        public IActionResult Index()
        {
            return View(weekRepository.GetWeeks());
        }


        public IActionResult AddWeek()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Addweek(Week week)
        {
            try
            {
                weekRepository.AddWeek(week);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return View();

            }
        }
        public IActionResult DeleteWeek(int id)
        {
            weekRepository.DeleteWeek(id);
            return View();

        }

        //[HttpPost]
        //public IActionResult DeleteWeek(Week deleteId)
        //{
        //    if (deleteId != null)
        //    {
        //        weekRepository.DeleteWeek(deleteId.Id);

        //        return View();
        //    }
        //    return View();
        //}


        public IActionResult UpdateWeek(int id)
        {
            {
                return View(weekRepository.Where(x => x.Id == id).FirstOrDefault());


            }

        }

        [HttpPost]
        public IActionResult UpdateWeek(Week week)
        {
            weekRepository.UpdateWeeks(week);
            return RedirectToAction("Index");
        }
    }
}
