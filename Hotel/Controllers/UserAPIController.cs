using AutoMapper;
using EFCore.BulkExtensions;
using Hotel.Context;
using Hotel.DBClass;
using Hotel.DBViewModel;
using Hotel.EncryptionDecryption;
using Hotel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Mapping;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {

        SqlContext _project;
        IConfiguration _config;
        IMapper _map;
        public UserAPIController(SqlContext project, IConfiguration config, IMapper map)
        {
            _project = project;
            _config = config;
            _map = map;
        }



        [HttpPost]
        [Route("InsertUser")]
        public async Task<ActionResult> InsertUser(UserModal obj)
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {
                Users newUser = _map.Map<Users>(obj);
                newUser.UserStatus = 1;
                newUser.Password = EncryptDecrypt.Encrypt(newUser.Password);
                newUser.InsertionDateTime = DateTime.UtcNow;
                _project.User.Add(newUser);
                _project.SaveChanges();
                res.Status = "Insertion successfull";
            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return Ok(res);
        }


        [HttpPost]
        [Route("InsertUserA")]
        public async Task<ActionResult> InsertUserA(UserModal obj)
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {
                Users newUser = _map.Map<Users>(obj);
                newUser.UserStatus = 1;
                newUser.Password = EncryptDecrypt.Encrypt(newUser.Password);
                newUser.InsertionDateTime = DateTime.UtcNow;
                newUser.RoleTitle = "User";
                _project.User.Add(newUser);
                _project.SaveChanges();
                res.Status = "Insertion successfull";
            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return Ok(res);
        }


        [HttpPost]
        [Route("UpdateUser")]
        public async Task<ActionResult> UpdateUser(UpdateUSerModal obj)
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {
                var newUser = _project.User.Find(obj.UserId);
                newUser.UserStatus = 1;
                newUser.UserTitle = obj.UserTitle;
                newUser.Email = obj.Email;
                newUser.PhoneNo = obj.PhoneNo;
                newUser.RoleTitle = obj.RoleTitle;
                _project.User.Update(newUser);
                _project.SaveChanges();
                res.Status = "Updated successfull";


            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return Ok(res);
        }


        [HttpPost]
        [Route("ManagePermissionByRole")]
        public async Task<ActionResult> ManagePermissionByRole(PermissionManagement obj)
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {

                List<PermissionAssignToRoles> PermissionAssignList = new List<PermissionAssignToRoles>();
                foreach (UnAssignedPermissions unA in obj.UnAssignedPermissionList)
                {
                    PermissionAssignToRoles PAToRole = new PermissionAssignToRoles();
                    PAToRole.AssignedDateTime = DateTime.Now;
                    PAToRole.PermissionId = unA.PermissionId;
                    PAToRole.RoleId = obj.RoleId;
                    PAToRole.Status = 1;

                    PermissionAssignList.Add(PAToRole);
                }
                if (PermissionAssignList.Count>0)
                {
                    await _project.BulkInsertAsync(PermissionAssignList);
                }
                List<int> Assigned = obj.AssignedPermissionList.Select(s=>s.AssignedId).ToList();

                List<PermissionAssignToRoles> AssignedPermissionList = _project.PermissionAssignToRole.Where(p => Assigned.Contains(p.AssignedId)).ToList();

                foreach(PermissionAssignToRoles passign in AssignedPermissionList)
                {
                    passign.Status = 0;                    
                }

                await _project.BulkUpdateAsync(AssignedPermissionList);

                res.Status = "Updated successfull";


            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return Ok(res);
        }




        [HttpPost]
        [Route("DeleteUser")]
        public async Task<ActionResult> DeleteUser(DeleteUSerModal obj)
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {
                var newUser = _project.User.Find(obj.UserId);
                newUser.UserStatus = obj.UserStatus;
                _project.User.Update(newUser);
                _project.SaveChanges();
                res.Status = "Delete successfull";
            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return Ok(res);
        }
        // Api To get User List
        [HttpGet]
        [Route("GetAllUser")]
        public async Task<ActionResult> GetAllUser(int PageNumber)
        {
            await Task.Delay(0);
            ListClass ResponseObject = new ListClass();
            if (PageNumber==0)
            {
                ResponseObject.CurrentPage = 1;
            }
            else
            {
                ResponseObject.CurrentPage = PageNumber;
            }
            var UserList = (from fod in _project.User
                            join std in _project.Role on fod.RoleTitle equals std.RoleTitle
                            select new
                            {
                                UserId = fod.UserId,
                                Name = fod.UserTitle,
                                Email = fod.Email,
                                Status = fod.UserStatus,
                                RoleTitle = std.RoleTitle,
                                RoleID = std.RoleId,
                            }).ToList();
            ResponseObject.TotalRecords = UserList.Count;
            ResponseObject.Data = UserList.Skip(ResponseObject.PageSize * (PageNumber - 1)).Take(ResponseObject.PageSize).ToList();
            return Ok(ResponseObject);
        }
        [HttpGet]
        [Route("AllUser")]
        public async Task<ActionResult> AllUser()
        {
            await Task.Delay(0);
            try
            {
                List<Users> RoleList = _project.User.ToList();


                return Ok(RoleList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult> GetAllUsers(int PageNumber)
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
            var UserList = _project.User.ToList();
            ResponseObject.TotalRecords = UserList.Count;
            ResponseObject.Data = UserList.Skip(ResponseObject.PageSize * (PageNumber - 1)).Take(ResponseObject.PageSize).ToList();
            return Ok(ResponseObject);
        }
        [HttpPost]
        [Route("LoginUser")]
        public Response LoginUser(Users stdObject)
        {
            Response res = new Response();
            try
            {
                Users newstd = _project.User.Where(std => std.Email.Equals(stdObject.Email) && std.Password.Equals(EncryptDecrypt.Encrypt(stdObject.Password))).FirstOrDefault();
                if (newstd == default)
                {
                    res.Status = "Invalid UserName / Password";
                }
                else
                {
                    res.Status = "login successfully";
                    //string id = HttpContext.User.FindFirstValue("userId");
                    //res.Token = JWTs.GenerateJSONWebToken(newstd, _config);
                    res.Token = stdObject.Email;
                }
            }
            catch
            {
                res.Status = "Failed";
            }

            return res;
        }
        [HttpPost]
        [Route("EmailCheck")]
        public Response EmailCheck(Users stdObject)
        {
            Response res = new Response();
            try
            {
                Users newstd = _project.User.Where(std => std.Email.Equals(stdObject.Email)).FirstOrDefault();
                if (newstd == default)
                {
                    res.Status = "Email verified";
                }
                else
                {
                    res.Status = "Email already exist";
                }
            }
            catch
            {
                res.Status = "Failed";
            }

            return res;
        }
    }
}
