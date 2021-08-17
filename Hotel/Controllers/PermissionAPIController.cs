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
    public class PermissionAPIController : ControllerBase
    {

        SqlContext _project;
        IConfiguration _config;
        IMapper _map;
        public PermissionAPIController(SqlContext project, IConfiguration config, IMapper map)
        {
            _project = project;
            _config = config;
            _map = map;
        }

        [HttpPost]
        [Route("InsertPermission")]
        public async Task<ActionResult> InsertPermission(PermissionModal permission)
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {
                Permissions NewPermission = _map.Map<Permissions>(permission);
                NewPermission.PermissionStatus = 1;
                NewPermission.PermissionDateTime = DateTime.UtcNow;
                _project.Permission.Add(NewPermission);
                _project.SaveChanges();
                res.Status = "Permission Added";


            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return Ok(res);
        }

        [HttpPut]
        [Route("UpdatePermission")]
        public async Task<ActionResult> UpdatePermission(UpdatePermissionModal obj)
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {
                var newPermission = _project.Permission.Find(obj.PermissionId);
                newPermission.PermissionStatus = 1;
                newPermission.PermissionTitle = obj.PermissionTitle;
                newPermission.PermissionUrl = obj.PermissionUrl;
                newPermission.IconCode = obj.IconCode;
                newPermission.IsMenu = obj.IsMenu;
                _project.Permission.Update(newPermission);
                _project.SaveChanges();
                res.Status = "Updated successfull";
            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return Ok(res);
        }
        [HttpPut]
        [Route("ActivatePermission")]
        public async Task<ActionResult> ActivatePermission(UpdatePermissionModal obj)
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {
                var newPermission = _project.Permission.Find(obj.PermissionId);
                newPermission.PermissionStatus = 1;
                _project.Permission.Update(newPermission);
                _project.SaveChanges();
                res.Status = "Activate successfull";
                res.Id = newPermission.PermissionId;
            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return Ok(res);
        }
        [HttpPut]
        [Route("DeactivatePermission")]
        public async Task<ActionResult> DeactivatePermission(UpdatePermissionModal obj)
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {
                var newPermission = _project.Permission.Find(obj.PermissionId);
                newPermission.PermissionStatus = 0;

                _project.Permission.Update(newPermission);
                _project.SaveChanges();
                res.Status = "Deactivate successfull";
                res.Id = newPermission.PermissionId;
            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return Ok(res);
        }
        [HttpPost]
        [Route("DeleteUser")]
        public async Task<ActionResult> DeleteUser(DeletePermissionModal obj)
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {
                var newPermission = _project.Permission.Find(obj.PermissionId);
                newPermission.PermissionStatus = 0;
                _project.Permission.Update(newPermission);
                _project.SaveChanges();
                res.Status = "Delete successfull";
            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return Ok(res);
        }


        [HttpGet]
        [Route("GetPermission")]
        public async Task<ActionResult> GetPermission()
        {
            await Task.Delay(0);
            try
            {
                List<Permissions> PermissionList = _project.Permission.ToList();
                return Ok(PermissionList);
            }
            catch
            {
                return null;
            }

        }

        [HttpPost]
        [Route("GetAllPermissionByRole")]
        public async Task<ActionResult> GetAllPermissionByRole(Roles role)
        {
            await Task.Delay(0);
            var UserList = (from perm in _project.Permission
                            where (perm.PermissionStatus == 1)
                            join permAssign in _project.PermissionAssignToRole.Where(r => r.RoleId == role.RoleId && r.Status == 1)
                            on perm.PermissionId equals permAssign.PermissionId into PAssign1
                            from PAssign2 in PAssign1.DefaultIfEmpty()
                            select new
                            {
                                PermissionId = perm.PermissionId,
                                PermissionTitle = perm.PermissionTitle,
                                AssignedId = (PAssign2 == null ? 0 : PAssign2.AssignedId)
                            }).ToList();

            return Ok(UserList);
        }
    }
}
