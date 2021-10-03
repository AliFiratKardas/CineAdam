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

    public class SessionController : Controller
    {
        private readonly ISessionRepository sessionRepository;
        public SessionController(ISessionRepository _sessionRepository)
        {
            sessionRepository = _sessionRepository;
        }
        public IActionResult Index()
        {
            return View(sessionRepository.GetSession());
        }



        public IActionResult AddSession()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddSession(Session session)
        {
            try
            {
                sessionRepository.AddSession(session);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return View();

            }
        }
        public IActionResult DeleteSession(int id)
        {
            sessionRepository.DeleteSession(id);
            return View();

        }



        public IActionResult UpdateSession(int id)
        {
            {
                return View(sessionRepository.Where(x => x.Id == id).FirstOrDefault());


            }

        }

        [HttpPost]
        public IActionResult UpdateSession(Session session)
        {
            sessionRepository.UpdateSession(session);
            return RedirectToAction("Index");
        }
    }
}
