using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DBViewModel
{
    public class UpdatePermissionModal
    {
        public int PermissionId { get; set; }
        public string PermissionTitle { get; set; }
        public string PermissionUrl { get; set; }
        public string IconCode { get; set; }
        public bool IsMenu { get; set; }
    }
}
