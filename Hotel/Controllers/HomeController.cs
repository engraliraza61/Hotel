using Hotel.Context;
using Hotel.DBClass;
using Hotel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        IWebHostEnvironment MyHostingPath;
        SqlContext _project;
        IConfiguration _config;
        public HomeController(IWebHostEnvironment currentHosting, SqlContext project, IConfiguration config)
        {
            MyHostingPath = currentHosting;
            _project=project;
            _config = config;
        }
        public IActionResult Index()
        {
            if (Request.Cookies["token"] == null)
            {
                return RedirectToActionPermanent("Login");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult MYFileUploadingMethod()
        {

            string roomId = Request.Form["RoomId"].ToString();
            MyHostingPath.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            if (Request.Form.Files.Count > 0)
            {
                string FileCompletePath = "";
                string FileExtention = "";
                string UniqueId = "";
                string BAsePath = "";
                string DBFileAddress = "";
                for (int i = 0; i < Request.Form.Files.Count; i++)
                {
                    BAsePath = MyHostingPath.WebRootPath + "/UserFiles/";
                    UniqueId = Guid.NewGuid().ToString();
                    FileExtention = Path.GetExtension(Request.Form.Files[i].FileName);
                    FileCompletePath = BAsePath + UniqueId + FileExtention;

                    DBFileAddress = "/UserFiles/" + UniqueId + FileExtention;


                    using (var FileUploadingStream = new FileStream(FileCompletePath, FileMode.Create))
                    {
                        Request.Form.Files[i].CopyTo(FileUploadingStream);
                    }




                    //try
                    //{
                    //    Rooms newList = _project.Room.Find(roomId);
                    //    newList.Photo = FileCompletePath;
                    //    _project.Room.Add(newList);
                    //    _project.SaveChanges();
                    //}
                    //catch (Exception ex)
                    //{
                    //    return Json(ex.Message);
                    //}

                }
                return Json("File Uploaded successfully");
            }
            else
            {
                return Json("No File Uploaded");
            }

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
        public IActionResult BookedRoom(string id)
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
        public IActionResult EditRoom(string Id)
        {
            ViewBag.Id = Id;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
