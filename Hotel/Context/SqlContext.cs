using Hotel.DBClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Context
{
    public class SqlContext: DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options): base(options)
        {
        }

        public DbSet<Permissions> Permission { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<PermissionAssignToRoles> PermissionAssignToRole { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<Rooms> Room { get; set; }

    }
}
