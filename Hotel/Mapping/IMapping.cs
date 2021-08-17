using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DBClass;
using Hotel.DBViewModel;

namespace Hotel.Mapping
{
    public class IMapping : Profile
    {
        public IMapping()
        {
            CreateMap<RoleModal, Roles>().ReverseMap();
            CreateMap<PermissionModal, Permissions>().ReverseMap();
            CreateMap<UserModal, Users>().ReverseMap();
            CreateMap<UpdateUSerModal, Users>().ReverseMap();
            CreateMap<DeleteUSerModal, Users>().ReverseMap();
            CreateMap<UpdatePermissionModal, Permissions>().ReverseMap();
            CreateMap<DeletePermissionModal, Permissions>().ReverseMap();
            CreateMap<UpdateRoleModal, Roles>().ReverseMap();
            CreateMap<DeleteRoleModal, Roles>().ReverseMap();
            CreateMap<RoomModal, Rooms>().ReverseMap();

        }
    }
}
