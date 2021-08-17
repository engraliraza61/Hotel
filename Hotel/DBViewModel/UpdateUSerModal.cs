using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DBViewModel
{
    public class UpdateUSerModal
    {
        public int UserId { get; set; }
        public string UserTitle { get; set; }
        public string Email { get; set; }
        public string RoleTitle { get; set; }
    }
}
