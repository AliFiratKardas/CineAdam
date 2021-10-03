using DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

       
        public IActionResult Index()
        {
            return View(userRepository.GetUsers());
        }


        public IActionResult AddUser()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {

            try
            {
                userRepository.AddUser(user);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public IActionResult DeleteUser(int userId)
        {
            userRepository.DeleteUser(userId);
            return View();

        }




        public IActionResult UpdateUser(int id)
        {
            {
                //userRepository.Where(x => x.Id == id).FirstOrDefault()
                return View();


            }

        }

        [HttpPost]
        public IActionResult UpdateWeek(User user)
        {
            userRepository.UpdateUser(user);
            return RedirectToAction("Index");
        }




    }
}
