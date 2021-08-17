using AutoMapper;
using Hotel.Context;
using Hotel.DBClass;
using Hotel.DBViewModel;
using Hotel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAPIController : ControllerBase
    {

        SqlContext _project;
        IConfiguration _config;
        IMapper _map;
        public RoomAPIController(SqlContext project, IConfiguration config, IMapper map)
        {
            _project = project;
            _config = config;
            _map = map;
        }

        [HttpPost]
        [Route("InsertRoom")]
        public async Task<ActionResult> InsertRoom(RoomModal permission)
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {
                Rooms NewRoom = _map.Map<Rooms>(permission);
                NewRoom.Status = 1;
                NewRoom.InsertDateTime = DateTime.UtcNow;
                _project.Room.Add(NewRoom);
                _project.SaveChanges();
                res.Status = "Room Added";
            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return Ok(res);
        }
        [HttpGet]
        [Route("GetAllRooms")]
        public async Task<ActionResult> GetAllRooms(int PageNumber)
        {
            await Task.Delay(0);
            ListClass ResponseObject = new ListClass();
            if (PageNumber == 0)
            {
                ResponseObject.CurrentPage = 1;
            }
            else
            {
                ResponseObject.CurrentPage = PageNumber;
            }
            var RoomList = _project.Room.ToList();
            ResponseObject.TotalRecords = RoomList.Count;
            ResponseObject.Data = RoomList.Skip(ResponseObject.PageSize * (PageNumber - 1)).Take(ResponseObject.PageSize).ToList();
            return Ok(ResponseObject);
        }
        //[HttpGet]
        //[Route("GetAllRoom")]
        //public async Task<ActionResult> GetAllRoom(int PageNumber)
        //{
        //    await Task.Delay(0);
        //    ListClass ResponseObject = new ListClass();
        //    if (PageNumber == 0)
        //    {
        //        ResponseObject.CurrentPage = 1;
        //    }
        //    else
        //    {
        //        ResponseObject.CurrentPage = PageNumber;
        //    }
        //    var UserList = (from fod in _project.User
        //                    join std in _project.Role on fod.RoleTitle equals std.RoleTitle
        //                    select new
        //                    {
        //                        RoomId = fod.UserId,
        //                        Name = fod.UserTitle,
        //                        Email = fod.Email,
        //                        Status = fod.UserStatus,
        //                        RoleTitle = std.RoleTitle,
        //                        RoleID = std.RoleId,
        //                    }).ToList();
        //    ResponseObject.TotalRecords = UserList.Count;
        //    ResponseObject.Data = UserList.Skip(ResponseObject.PageSize * (PageNumber - 1)).Take(ResponseObject.PageSize).ToList();
        //    return Ok(ResponseObject);
        //}
    }
}
