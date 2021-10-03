using DataAccess.Context;
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
    public class ReservationController : Controller
    {
        private readonly IReservationRepository reservationRepository;
        public ReservationController(IReservationRepository _reservationRepository)
        {
            reservationRepository = _reservationRepository;
        }


        public IActionResult Index()
        {
            return View(reservationRepository.GetReservation());
        }
        public IActionResult AddReservation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddReserVation(Reservation reservation)
        {
            try
            {
                reservationRepository.AddReservation(reservation);
                return RedirectToAction("Index");


            }
            catch (Exception )
            {
                return View();
            }
        }
    }
}
