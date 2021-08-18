using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string Token)
        {
            ViewBag.Token = Token;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Role()
        {
            return View();
        }
        public IActionResult Permission()
        {
            return View();
        }
        public IActionResult PermissionAssignToRole(string id)
        {
            ViewBag.id = id;
            return View();
        }
        public IActionResult User()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult AddBooking()
        {
            return View();
        }
        public IActionResult AddRoom()
        {
            return View();
        }
        public IActionResult AllRoom()
        {
            return View();
        }
        public IActionResult AllRooms()
        {
            return View();
        }
        public IActionResult EditRoom(string roomId)
        {
            ViewBag.roomId = roomId;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
