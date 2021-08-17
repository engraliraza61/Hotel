using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DBClass
{
    public class Permissions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermissionId { get; set; }
        public string PermissionTitle { get; set; }
        public int PermissionStatus { get; set; }
        public string PermissionUrl { get; set; }
        public string IconCode { get; set; }
        public bool IsMenu { get; set; }
        public DateTime PermissionDateTime { get; set; }

       
    }
}
