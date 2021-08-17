using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DBClass
{
    public class PermissionAssignToRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssignedId { get; set; }
        public int? RoleId { get; set; }
        public int? PermissionId { get; set; }
        public int? UserId { get; set; }
        public int? Status { get; set; }
        public DateTime? AssignedDateTime { get; set; }
    }
}
